using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using GameLib.Areas.Admin.ViewModels.BlogAuthor;
using GameLib.Areas.Admin.ViewModels.Platform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Interfaces;

namespace GameLib.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PlatformController : Controller
    {
        private readonly IPlatformService _plarformService;

        public PlatformController(IPlatformService plarformService)
        {
            _plarformService = plarformService;
        }



        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<Platform> platforms = await _plarformService.GetAllAsync();

                List<PlatformListVM> model = new List<PlatformListVM>();

                foreach (var platform in platforms)
                {
                    model.Add(new PlatformListVM
                    {
                        Id = platform.Id,
                        Name = platform.Name
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

                Platform platform = await _plarformService.GetByIdAsync(id);

                if (platform is null) throw new NullReferenceException();

                PlatformDetailsVM model = new PlatformDetailsVM
                {
                    Name = platform.Name,
                    CreatedAt = platform.CreatedAt,
                    ModifiedAt = platform.ModifiedAt
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
        public async Task<IActionResult> Create(PlatformCreateVM model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                IEnumerable<Platform> platforms = await _plarformService.GetAllAsync();

                foreach (var platform in platforms)
                {
                    if (platform.Name.Trim().ToLower() == model.Name.Trim().ToLower())
                    {
                        ModelState.AddModelError("Name", "Platform with this name is already exists.");
                        return View(model);
                    }
                }

                Platform newPlatform = new Platform
                {
                    Name = model.Name
                };

                await _plarformService.CreateAsync(newPlatform);

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

                Platform platform = await _plarformService.GetByIdAsync(id);

                if (platform is null) throw new NullReferenceException();

                PlatformEditVM model = new PlatformEditVM
                {
                    Id = platform.Id,
                    Name = platform.Name
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
        public async Task<IActionResult> Edit(PlatformEditVM model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                IEnumerable<Platform> platforms = await _plarformService.GetAllAsync();

                foreach (var platform in platforms)
                {
                    if (platform.Name.Trim().ToLower() == model.Name.Trim().ToLower() && platform.Id != model.Id)
                    {
                        ModelState.AddModelError("Name", "Platform with this name is already exists.");
                        return View(model);
                    }
                }

                Platform oldPlatform = await _plarformService.GetByIdAsync(model.Id);

                if (oldPlatform is null) throw new NullReferenceException();

                Platform updatedPlatform = new Platform
                {
                    Id = model.Id,
                    Name = model.Name,
                    CreatedAt = oldPlatform.CreatedAt,
                    ModifiedAt = DateTime.Now
                };

                await _plarformService.UpdateAsync(updatedPlatform);

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

                Platform platform = await _plarformService.GetByIdAsync(id);

                if (platform is null) throw new NullReferenceException();

                await _plarformService.DeleteAsync(platform);

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