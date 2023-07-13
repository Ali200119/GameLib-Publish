using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using GameLib.Areas.Admin.ViewModels.Advantage;
using GameLib.Areas.Admin.ViewModels.BlogAuthor;
using GameLib.Helpers.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Interfaces;

namespace GameLib.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogAuthorController : Controller
    {
        private readonly IBlogAuthorService _blogAuthorService;

        public BlogAuthorController(IBlogAuthorService blogAuthorService)
        {
            _blogAuthorService = blogAuthorService;
        }



        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<BlogAuthor> blogAuthors = await _blogAuthorService.GetAllAsync();

                List<BlogAuthorListVM> model = new List<BlogAuthorListVM>();

                foreach (var blogAuthor in blogAuthors)
                {
                    model.Add(new BlogAuthorListVM
                    {
                        Id = blogAuthor.Id,
                        Name = blogAuthor.Name
                    });
                }

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

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id is null) throw new ArgumentNullException();

                BlogAuthor blogAuthor = await _blogAuthorService.GetByIdAsync(id);

                if (blogAuthor is null) throw new NullReferenceException();

                BlogAuthorDetailsVM model = new BlogAuthorDetailsVM
                {
                    Name = blogAuthor.Name,
                    CreatedAt = blogAuthor.CreatedAt,
                    ModifiedAt = blogAuthor.ModifiedAt
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogAuthorCreateVM model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                BlogAuthor newBlogAuthor = new BlogAuthor
                {
                    Name = model.Name
                };

                await _blogAuthorService.CreateAsync(newBlogAuthor);

                return RedirectToAction(nameof(Index));
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

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id is null) throw new ArgumentNullException();

                BlogAuthor blogAuthor = await _blogAuthorService.GetByIdAsync(id);

                if (blogAuthor is null) throw new NullReferenceException();

                BlogAuthorEditVM model = new BlogAuthorEditVM
                {
                    Id = blogAuthor.Id,
                    Name = blogAuthor.Name
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BlogAuthorEditVM model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                BlogAuthor oldBlogAuthor = await _blogAuthorService.GetByIdAsync(model.Id);

                if (oldBlogAuthor is null) throw new NullReferenceException();

                BlogAuthor updatedBlogAuthor = new BlogAuthor
                {
                    Id = model.Id,
                    Name = model.Name,
                    CreatedAt = oldBlogAuthor.CreatedAt,
                    ModifiedAt = DateTime.Now
                };

                await _blogAuthorService.UpdateAsync(updatedBlogAuthor);

                return RedirectToAction(nameof(Index));
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id is null) throw new ArgumentNullException();

                BlogAuthor blogAuthor = await _blogAuthorService.GetByIdAsync(id);

                if (blogAuthor is null) throw new NullReferenceException();

                await _blogAuthorService.DeleteAsync(blogAuthor);

                return RedirectToAction(nameof(Index));
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
    }
}