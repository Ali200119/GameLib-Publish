using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace GameLib.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }



        [HttpPost]
        public async Task<IActionResult> SubscribeToNewsletter(string email)
        {
            try
            {
                if (email is null) throw new ArgumentNullException();

                bool response = await _subscribeService.Subscribe(email);

                return Ok(response);
            }

            catch (ArgumentNullException)
            {
                return BadRequest();
            }

            catch(NullReferenceException)
            {
                return NotFound();
            }
        }
    }
}