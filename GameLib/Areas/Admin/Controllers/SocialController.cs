using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using GameLib.Areas.Admin.ViewModels.Advantage;
using GameLib.Areas.Admin.ViewModels.Social;
using GameLib.Helpers.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Interfaces;

namespace GameLib.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SocialController : Controller
    {
        private readonly ISocialService _socialService;

        public SocialController(ISocialService socialService)
        {
            _socialService = socialService;
        }



        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<Social> socials = await _socialService.GetAllAsync();

                List<SocialListVM> model = new List<SocialListVM>();

                foreach (var social in socials)
                {
                    model.Add(new SocialListVM
                    {
                        Id = social.Id,
                        Name = social.Name,
                        Icon = social.Icon
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

                Social social = await _socialService.GetByIdAsync(id);

                if (social is null) throw new NullReferenceException();

                SocialDetailsVM model = new SocialDetailsVM
                {
                    Icon = social.Icon,
                    Name = social.Name,
                    Link = social.Link,
                    Color = social.Color,
                    CreatedAt = social.CreatedAt,
                    ModifiedAt = social.ModifiedAt
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
        public async Task<IActionResult> Create(SocialCreateVM model)
        {
            if (!ModelState.IsValid) return View(model);

            IEnumerable<Social> socials = await _socialService.GetAllAsync();

            foreach (var social in socials)
            {
                if (social.Name.Trim().ToLower() == model.Name.Trim().ToLower())
                {
                    ModelState.AddModelError("Name", "Social with this name is already exists.");
                    return View(model);
                }
            }

            Social newSocial = new Social
            {
                Name = model.Name,
                Icon = model.Icon,
                Link = model.Link,
                Color = model.Color.ToLower()
            };

            await _socialService.CreateAsync(newSocial);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id is null) throw new ArgumentNullException();

                Social social = await _socialService.GetByIdAsync(id);

                if (social is null) throw new NullReferenceException();

                SocialEditVM model = new SocialEditVM
                {
                    Id = social.Id,
                    Name = social.Name,
                    Icon = social.Icon,
                    Link = social.Link,
                    Color = social.Color
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
        public async Task<IActionResult> Edit(SocialEditVM model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                IEnumerable<Social> socials = await _socialService.GetAllAsync();

                foreach (var social in socials)
                {
                    if (social.Name.Trim().ToLower() == model.Name.Trim().ToLower() && social.Id != model.Id)
                    {
                        ModelState.AddModelError("Name", "Social with this name is already exists.");
                        return View(model);
                    }
                }

                Social oldSocial = await _socialService.GetByIdAsync(model.Id);

                if (oldSocial is null) throw new NullReferenceException();

                Social updatedSocial = new Social
                {
                    Id = model.Id,
                    Name = model.Name,
                    Icon = model.Icon,
                    Link = model.Link,
                    Color = model.Color.ToLower(),
                    CreatedAt = oldSocial.CreatedAt,
                    ModifiedAt = DateTime.Now
                };

                await _socialService.UpdateAsync(updatedSocial);

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

                Social social = await _socialService.GetByIdAsync(id);

                if (social is null) throw new NullReferenceException();

                await _socialService.DeleteAsync(social);

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