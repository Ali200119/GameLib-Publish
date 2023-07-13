using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using Service.ViewModels;

namespace GameLib.Controllers
{
    public class ContactController : Controller
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IContactService _contactService;
        private readonly ISocialService _socialService;

        public ContactController(IStaticDataService staticDataService,
                                 IContactService contactService,
                                 ISocialService socialService)
        {
            _staticDataService = staticDataService;
            _contactService = contactService;
            _socialService = socialService;
        }



        public async Task<IActionResult> Index()
        {
            Dictionary<string, string> sectionHeaders = _staticDataService.GetAllSectionHeaders();
            IEnumerable<Social> socials = await _socialService.GetAllAsync();

            ContactVM model = new ContactVM
            {
                SectionHeaders = sectionHeaders,
                Socials = socials,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                ContactVM model = new ContactVM
                {
                    SectionHeaders = _staticDataService.GetAllSectionHeaders(),
                    Socials = await _socialService.GetAllAsync(),
                    Contact = contact
                };

                return View(model);
            }

            await _contactService.CreateAsync(contact);

            return RedirectToAction("Index", "Home");
        }
    }
}