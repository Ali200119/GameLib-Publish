using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Models;
using GameLib.Areas.Admin.ViewModels.About;
using GameLib.Areas.Admin.ViewModels.Advantage;
using GameLib.Areas.Admin.ViewModels.Developer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;

namespace GameLib.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DeveloperController : Controller
    {
        private readonly IDeveloperService _developerService;
        private readonly IWebHostEnvironment _env;

        public DeveloperController(IDeveloperService developerService,
                                   IWebHostEnvironment env)
        {
            _developerService = developerService;
            _env = env;
        }



        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<Developer> developers = await _developerService.GetAllAsync();

                List<DeveloperListVM> model = new List<DeveloperListVM>();

                foreach (var developer in developers)
                {
                    model.Add(new DeveloperListVM
                    {
                        Id = developer.Id,
                        Name = developer.Name
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

                Developer developer = await _developerService.GetByIdAsync(id);

                if (developer is null) throw new NullReferenceException();

                DeveloperDetailsVM model = new DeveloperDetailsVM
                {
                    Logo = developer.Logo,
                    Name = developer.Name,
                    CreatedAt = developer.CreatedAt,
                    ModifiedAt = developer.ModifiedAt
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
        public async Task<IActionResult> Create(DeveloperCreateVM model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                IEnumerable<Developer> developers = await _developerService.GetAllAsync();

                if (!model.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File type must be image.");
                    return View(model);
                }

                foreach (var developer in developers)
                {
                    if (developer.Name.Trim().ToLower() == model.Name.Trim().ToLower())
                    {
                        ModelState.AddModelError("Name", "Developer with this name is already exists.");
                        return View(model);
                    }
                }

                string fileName = model.Photo.GenerateFileName();
                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/developers", fileName);

                await model.Photo.CreateLocalFileAsync(path);

                Developer newDeveloper = new Developer
                {
                    Logo = fileName,
                    Name = model.Name
                };

                await _developerService.CreateAsync(newDeveloper);

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

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id is null) throw new ArgumentNullException();

                Developer developer = await _developerService.GetByIdAsync(id);

                if (developer is null) throw new NullReferenceException();

                DeveloperEditVM model = new DeveloperEditVM
                {
                    Id = developer.Id,
                    Logo = developer.Logo,
                    Name = developer.Name
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
        public async Task<IActionResult> Edit(DeveloperEditVM model)
        {
            try
            {
                Developer oldDeveloper = await _developerService.GetByIdAsync(model.Id);

                if (oldDeveloper is null) throw new NullReferenceException();

                if (!ModelState.IsValid)
                {
                    model.Logo = oldDeveloper.Logo;
                    return View(model);
                }

                IEnumerable<Developer> developers = await _developerService.GetAllAsync();

                foreach (var developer in developers)
                {
                    if (developer.Name.Trim().ToLower() == model.Name.Trim().ToLower() && developer.Id != model.Id)
                    {
                        model.Logo = oldDeveloper.Logo;
                        ModelState.AddModelError("Name", "Developer with this name is already exists.");
                        return View(model);
                    }
                }

                if (model.Photo is null) model.Logo = oldDeveloper.Logo;

                else
                {
                    if (!model.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "File type must be image.");
                        model.Logo = oldDeveloper.Logo;
                        return View(model);
                    }

                    string fileName = model.Photo.GenerateFileName();
                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/developers", fileName);

                    string oldImagePath = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/developers", oldDeveloper.Logo);

                    await model.Photo.CreateLocalFileAsync(path);

                    FileHelper.DeleteFileFromPath(oldImagePath);

                    model.Logo = fileName;
                }

                Developer updatedDeveloper = new Developer
                {
                    Id = model.Id,
                    Logo = model.Logo,
                    Name = model.Name,
                    CreatedAt = oldDeveloper.CreatedAt,
                    ModifiedAt = DateTime.Now
                };

                await _developerService.UpdateAsync(updatedDeveloper);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id is null) throw new ArgumentNullException();

                Developer developer = await _developerService.GetByIdAsync((int)id);

                if (developer is null) throw new NullReferenceException();

                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/developers", developer.Logo);

                FileHelper.DeleteFileFromPath(path);

                await _developerService.DeleteAsync(developer);

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