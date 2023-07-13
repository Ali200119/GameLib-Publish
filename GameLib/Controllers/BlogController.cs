using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;
using Service.ViewModels;

namespace GameLib.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IStaticDataService _staticDataService;
        private readonly ISocialService _socialService;
        private readonly IBlogCommentService _blogCommentService;

        public BlogController(IBlogService blogService,
                              IStaticDataService staticDataService,
                              ISocialService socialService,
                              IBlogCommentService blogCommentService)
        {
            _blogService = blogService;
            _staticDataService = staticDataService;
            _socialService = socialService;
            _blogCommentService = blogCommentService;
        }



        public async Task<IActionResult> Index(int page = 1, int take = 3)
        {
            Dictionary<string, string> sectionHeaders = _staticDataService.GetAllSectionHeaders();
            IEnumerable<Blog> blogs = await _blogService.GetAllWithIncludesAsync();
            IEnumerable<Social> socials = await _socialService.GetAllAsync();

            Paginate<Blog> paginatedDatas = new Paginate<Blog>(await _blogService.GetPaginatedDatasAsync(page, take), page, await GetPageCountAsync(take));

            BlogVM model = new BlogVM
            {
                SectionHeaders = sectionHeaders,
                PaginatedDatas = paginatedDatas,
                Blogs = blogs,
                Socials = socials
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id is null) throw new ArgumentNullException();

                Dictionary<string, string> sectionHeaders = _staticDataService.GetAllSectionHeaders();
                Blog blog = await _blogService.GetByIdWithIncludesAsync(id);
                IEnumerable<Blog> latestBlogs = await _blogService.GetAllWithIncludesAsync();
                IEnumerable<Social> socials = await _socialService.GetAllAsync();
                IEnumerable<BlogComment> blogComments = await _blogCommentService.GetAllAsync(id);

                BlogDetailsVM model = new BlogDetailsVM
                {
                    SectionHeaders = sectionHeaders,
                    Blog = blog,
                    LatestBlogs = latestBlogs.OrderByDescending(b => b.CreatedAt).Take(4),
                    Socials = socials,
                    Comments = blogComments
                };

                return View(model);
            }

            catch (ArgumentNullException)
            {
                return BadRequest();
            }

            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostComment(BlogDetailsVM model, string userId, int? blogId)
        {
            try
            {
                if (userId is null || blogId is null) throw new ArgumentNullException();

                if (model.BlogComment.Comment is null)
                {
                    return RedirectToAction(nameof(Details), new { id = blogId });
                }

                BlogComment blogComment = new BlogComment
                {
                    Comment = model.BlogComment.Comment,
                    UserId = userId,
                    BlogId = (int)blogId
                };

                await _blogCommentService.CreateAsync(blogComment);

                return RedirectToAction(nameof(Details), new { id = blogId });
            }

            catch (ArgumentNullException)
            {
                return BadRequest();
            }

            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(int? id)
        {
            try
            {
                if (id is null) throw new ArgumentNullException();

                await _blogCommentService.DeleteAsync(id);

                return Ok();
            }

            catch (ArgumentNullException)
            {
                return BadRequest();
            }

            catch (NullReferenceException)
            {
                return NotFound();
            }
        }



        private async Task<int> GetPageCountAsync(int take)
        {
            int blogCount = await _blogService.GetCountAsync();

            return (int)Math.Ceiling((decimal)blogCount / take);
        }
    }
}