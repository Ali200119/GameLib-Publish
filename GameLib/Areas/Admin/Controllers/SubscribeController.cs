using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using GameLib.Areas.Admin.ViewModels.Platform;
using GameLib.Areas.Admin.ViewModels.Subscribe;
using GameLib.Helpers.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace GameLib.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SubscribeController : Controller
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }



        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<Subscribe> subscribers = await _subscribeService.GetAllAsync();

                List<SubscribeListVM> model = new List<SubscribeListVM>();

                foreach (var subscriber in subscribers)
                {
                    model.Add(new SubscribeListVM
                    {
                        Id = subscriber.Id,
                        Email = subscriber.Email
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

                Subscribe subscriber = await _subscribeService.GetByIdAsync(id);

                if (subscriber is null) throw new NullReferenceException();

                SubscribeDetailsVM model = new SubscribeDetailsVM
                {
                    Email = subscriber.Email,
                    CreatedAt = subscriber.CreatedAt
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
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id is null) throw new ArgumentNullException();

                Subscribe subscriber = await _subscribeService.GetByIdAsync(id);

                if (subscriber is null) throw new NullReferenceException();

                await _subscribeService.DeleteAsync(subscriber);

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