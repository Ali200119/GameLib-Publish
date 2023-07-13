using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using GameLib.Areas.Admin.ViewModels.Advantage;
using GameLib.Helpers.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace GameLib.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdvantageController : Controller
    {
        private readonly IAdvantageService _advantageService;

        public AdvantageController(IAdvantageService advantageService)
        {
            _advantageService = advantageService;
        }



        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<Advantage> advantages = await _advantageService.GetAllAsync();

                List<AdvantageListVM> model = new List<AdvantageListVM>();

                foreach (var advantage in advantages)
                {
                    model.Add(new AdvantageListVM
                    {
                        Id = advantage.Id,
                        Icon = advantage.Icon,
                        Title = advantage.Title
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

                Advantage advantage = await _advantageService.GetByIdAsync(id);

                AdvantageDetailsVM model = new AdvantageDetailsVM
                {
                    Icon = advantage.Icon,
                    Title = advantage.Title,
                    Description = advantage.Description,
                    CreatedAt = advantage.CreatedAt,
                    ModifiedAt = advantage.ModifiedAt
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
        public async Task<IActionResult> Create(AdvantageCreateVM model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                IEnumerable<Advantage> advantages = await _advantageService.GetAllAsync();

                foreach (var advantage in advantages)
                {
                    if (advantage.Title.Trim().ToLower() == model.Title.Trim().ToLower())
                    {
                        ModelState.AddModelError("Title", "Advantage with this title is already exists.");
                        return View(model);
                    }
                }

                Advantage newAdvantage = new Advantage
                {
                    Icon = model.Icon,
                    Title = model.Title,
                    Description = model.Description
                };

                await _advantageService.CreateAsync(newAdvantage);

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

                Advantage advantage = await _advantageService.GetByIdAsync(id);

                if (advantage is null) throw new NullReferenceException();

                AdvantageEditVM model = new AdvantageEditVM
                {
                    Id = advantage.Id,
                    Icon = advantage.Icon,
                    Title = advantage.Title,
                    Description = advantage.Description
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
        public async Task<IActionResult> Edit(AdvantageEditVM model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                IEnumerable<Advantage> advantages = await _advantageService.GetAllAsync();

                foreach (var advantage in advantages)
                {
                    if (advantage.Title.Trim().ToLower() == model.Title.Trim().ToLower() && advantage.Id != model.Id)
                    {
                        ModelState.AddModelError("Title", "Advantage with this title is already exists.");
                        return View(model);
                    }
                }

                Advantage oldAdvantage = await _advantageService.GetByIdAsync(model.Id);

                if (oldAdvantage is null) throw new NullReferenceException();

                Advantage updatedAdvantage = new Advantage
                {
                    Id = model.Id,
                    Icon = model.Icon,
                    Title = model.Title,
                    Description = model.Description,
                    CreatedAt = oldAdvantage.CreatedAt,
                    ModifiedAt = DateTime.Now
                };

                await _advantageService.UpdateAsync(updatedAdvantage);

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

                Advantage advantage = await _advantageService.GetByIdAsync(id);

                if (advantage is null) throw new NullReferenceException();

                await _advantageService.DeleteAsync(advantage);

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

