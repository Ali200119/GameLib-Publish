using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Models;
using GameLib.Areas.Admin.ViewModels.About;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers;
using Service.Services.Interfaces;

namespace GameLib.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IWebHostEnvironment _env;

        public AboutController(IAboutService aboutService,
                               IWebHostEnvironment env)
        {
            _aboutService = aboutService;
            _env = env;
        }



        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<About> about = await _aboutService.GetAsync();

                AboutVM model = new AboutVM
                {
                    Image = about.FirstOrDefault().Image,
                    Title = about.FirstOrDefault().Title
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
        public async Task<IActionResult> Details()
        {
            try
            {
                IEnumerable<About> about = await _aboutService.GetAsync();

                AboutDetailsVM model = new AboutDetailsVM
                {
                    Image = about.FirstOrDefault().Image,
                    Title = about.FirstOrDefault().Title,
                    Description = about.FirstOrDefault().Description,
                    CreatedAt = about.FirstOrDefault().CreatedAt,
                    ModifiedAt = about.FirstOrDefault().ModifiedAt
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
        public async Task<IActionResult> Edit()
        {
            try
            {
                IEnumerable<About> about = await _aboutService.GetAsync();

                AboutEditVM model = new AboutEditVM
                {
                    Id = about.FirstOrDefault().Id,
                    Image = about.FirstOrDefault().Image,
                    Title = about.FirstOrDefault().Title,
                    Description = about.FirstOrDefault().Description
                };

                return View(model);
            }

            catch (ArgumentException)
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
        public async Task<IActionResult> Edit(AboutEditVM model)
        {
            try
            {
                IEnumerable<About> about = await _aboutService.GetAsync();

                if (!ModelState.IsValid)
                {
                    model.Image = about.FirstOrDefault().Image;
                    return View(model);
                }

                if (model.Photo is null) model.Image = about.FirstOrDefault().Image;

                else
                {
                    if (!model.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "File type must be image.");
                        model.Image = about.FirstOrDefault().Image;
                        return View(model);
                    }

                    string fileName = model.Photo.GenerateFileName();
                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/about", fileName);

                    string oldImagePath = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/about", about.FirstOrDefault().Image);

                    await model.Photo.CreateLocalFileAsync(path);

                    FileHelper.DeleteFileFromPath(oldImagePath);

                    model.Image = fileName;
                }

                About updatedAbout = new About
                {
                    Id = model.Id,
                    Image = model.Image,
                    Title = model.Title,
                    Description = model.Description,
                    CreatedAt = about.FirstOrDefault().CreatedAt,
                    ModifiedAt = DateTime.Now
                };

                await _aboutService.UpdateAsync(updatedAbout);

                return RedirectToAction(nameof(Index));
            }

            catch (ArgumentException)
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

