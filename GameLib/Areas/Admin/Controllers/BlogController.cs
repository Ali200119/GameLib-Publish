using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using GameLib.Areas.Admin.ViewModels.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Service.Helpers;
using Service.Services.Interfaces;

namespace GameLib.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IBlogAuthorService _blogAuthorService;
        private readonly IWebHostEnvironment _env;
        private readonly IBlogImageService _blogImageService;
        private readonly AppDbContext _context;

        public BlogController(IBlogService blogService,
                              IBlogAuthorService blogAuthorService,
                              IWebHostEnvironment env,
                              IBlogImageService blogImageService,
                              AppDbContext context)
        {
            _blogService = blogService;
            _blogAuthorService = blogAuthorService;
            _env = env;
            _blogImageService = blogImageService;
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            IEnumerable<Blog> blogs = await _blogService.GetAllWithIncludesAsync();

            List<BlogListVM> model = new List<BlogListVM>();

            foreach (var blog in blogs)
            {
                model.Add(new BlogListVM
                {
                    Id = blog.Id,
                    MainImage = blog.BlogImages.FirstOrDefault(bi => bi.IsMain).Name,
                    Title = blog.Title,
                    Game = blog.Game
                });
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.BlogAuthors = await GetBlogAuthorsAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCreateVM model)
        {
            ViewBag.BlogAuthors = await GetBlogAuthorsAsync();

            if (!ModelState.IsValid) return View(model);

            foreach (var photo in model.Photos)
            {
                if (!photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photos", "File type must be image.");
                    return View(model);
                }
            }

            IEnumerable<Blog> blogs = await _blogService.GetAllWithIncludesAsync();

            List<BlogImage> blogImages = new List<BlogImage>();

            foreach (var photo in model.Photos)
            {
                string fileName = photo.GenerateFileName();
                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/blog", fileName);

                await photo.CreateLocalFileAsync(path);

                BlogImage blogImage = new BlogImage
                {
                    Name = fileName
                };

                blogImages.Add(blogImage);
            }

            blogImages.FirstOrDefault().IsMain = true;

            if (model.FavBlog)
            {
                Blog favBlog = blogs.FirstOrDefault(b => b.FavBlog);

                favBlog.FavBlog = false;

                await _blogService.UpdateAsync(favBlog);
            }

            Blog newBlog = new Blog
            {
                Title = model.Title,
                Game = model.Game,
                ShortDescription = model.ShortDescription,
                Description = model.Description,
                FavBlog = model.FavBlog,
                BlogImages = blogImages,
                BlogAuthorId = model.BlogAuthorId
            };

            await _blogService.CreateAsync(newBlog);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            Blog blog = await _blogService.GetByIdWithIncludesAsync(id);

            if (blog is null) throw new NullReferenceException();


            List<string> images = new List<string>();

            foreach (var image in blog.BlogImages)
            {
                images.Add(image.Name);
            }


            BlogDetailsVM model = new BlogDetailsVM
            {
                Title = blog.Title,
                Game = blog.Game,
                ShortDescription = blog.ShortDescription,
                Description = blog.Description,
                BlogAuthor = blog.BlogAuthor.Name,
                FavBlog = blog.FavBlog,
                Images = images,
                CreatedAt = blog.CreatedAt,
                ModifiedAt = blog.ModifiedAt
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.BlogAuthors = await GetBlogAuthorsAsync();

            if (id is null) throw new ArgumentNullException();

            Blog blog = await _blogService.GetByIdWithIncludesAsync(id);

            if (blog is null) throw new NullReferenceException();

            List<string> images = new List<string>();

            foreach (var image in blog.BlogImages)
            {
                images.Add(image.Name);
            }

            BlogEditVM model = new BlogEditVM
            {
                Id = blog.Id,
                Title = blog.Title,
                Game = blog.Game,
                ShortDescription = blog.ShortDescription,
                Description = blog.Description,
                BlogAuthorId = blog.BlogAuthorId,
                FavBlog = blog.FavBlog,
                Images = images
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BlogEditVM model)
        {
            ViewBag.BlogAuthors = await GetBlogAuthorsAsync();

            Blog blog = await _blogService.GetByIdWithIncludesAsync(model.Id);

            if (blog is null) throw new NullReferenceException();

            List<string> images = new List<string>();

            foreach (var image in blog.BlogImages)
            {
                images.Add(image.Name);
            }

            model.Images = images;

            if (!ModelState.IsValid) return View(model);

            List<BlogImage> blogImages = new List<BlogImage>();

            if (model.Photos is null)
            {
                foreach (var image in blog.BlogImages)
                {
                    blogImages.Add(image);
                }
            }

            else
            {
                foreach (var photo in model.Photos)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photos", "File type must be image.");
                        return View(model);
                    }
                }

                foreach (var photo in model.Photos)
                {
                    string fileName = photo.GenerateFileName();
                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/blog", fileName);

                    await photo.CreateLocalFileAsync(path);

                    BlogImage blogImage = new BlogImage
                    {
                        Name = fileName
                    };

                    blogImages.Add(blogImage);
                }

                blogImages.FirstOrDefault().IsMain = true;

                IEnumerable<BlogImage> dbBlogImages = await _blogImageService.GetAllByBlogIdAsync(model.Id);

                foreach (var image in dbBlogImages)
                {
                    string oldPathImage = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/blog", image.Name);

                    FileHelper.DeleteFileFromPath(oldPathImage);

                    await _blogImageService.DeleteAsync(image);
                }
            }

            IEnumerable<Blog> blogs = await _blogService.GetAllWithIncludesAsync();

            if (model.FavBlog)
            {
                Blog favBlog = blogs.FirstOrDefault(b => b.FavBlog);

                favBlog.FavBlog = false;

                await _blogService.UpdateAsync(favBlog);
            }

            Blog updatedBlog = new Blog
            {
                Id = model.Id,
                Title = model.Title,
                Game = model.Game,
                ShortDescription = model.ShortDescription,
                Description = model.Description,
                FavBlog = model.FavBlog,
                BlogAuthorId = model.BlogAuthorId,
                BlogImages = blogImages,
                CreatedAt = blog.CreatedAt,
                ModifiedAt = DateTime.Now
            };

            await _blogService.UpdateAsync(updatedBlog);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            Blog blog = await _blogService.GetByIdWithIncludesAsync(id);

            if (blog is null) throw new NullReferenceException();

            foreach (var image in blog.BlogImages)
            {
                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/blog", image.Name);

                FileHelper.DeleteFileFromPath(path);
            }

            await _blogService.DeleteAsync(blog);

            if (blog.FavBlog)
            {
                IEnumerable<Blog> blogs = await _blogService.GetAllWithIncludesAsync();

                Blog firstBlog = blogs.FirstOrDefault();

                firstBlog.FavBlog = true;

                await _blogService.UpdateAsync(firstBlog);
            }

            return RedirectToAction(nameof(Index));
        }



        private async Task<SelectList> GetBlogAuthorsAsync()
        {
            IEnumerable<BlogAuthor> blogAuthors = await _blogAuthorService.GetAllAsync();

            return new SelectList(blogAuthors, "Id", "Name");
        }
    }
}