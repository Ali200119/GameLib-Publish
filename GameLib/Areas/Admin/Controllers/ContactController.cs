using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using GameLib.Areas.Admin.ViewModels.About;
using GameLib.Areas.Admin.ViewModels.Contact;
using GameLib.Helpers.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Interfaces;

namespace GameLib.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }



        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<Contact> contacts = await _contactService.GetAllAsync();

                List<ContactListVM> model = new List<ContactListVM>();

                foreach (var contact in contacts)
                {
                    model.Add(new ContactListVM
                    {
                        Id = contact.Id,
                        Email = contact.Email,
                        FullName = contact.FullName
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
                Contact contact = await _contactService.GetByIdAsync(id);

                ContactDetailsVM model = new ContactDetailsVM
                {
                    Email = contact.Email,
                    FullName = contact.FullName,
                    Message = contact.Message,
                    CreatedAt = contact.CreatedAt
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

                Contact contact = await _contactService.GetByIdAsync(id);

                if (contact is null) throw new NullReferenceException();

                await _contactService.DeleteAsync(contact);

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

