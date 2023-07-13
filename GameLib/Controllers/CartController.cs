using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using Service.ViewModels;

namespace GameLib.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IGameService _gameService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;

        public CartController(ICartService cartService,
                              IGameService gameService,
                              UserManager<AppUser> userManager,
                              IEmailService emailService)
        {
            _cartService = cartService;
            _gameService = gameService;
            _userManager = userManager;
            _emailService = emailService;
        }



        public async Task<IActionResult> Index(string userId)
        {
            try
            {
                if (userId is null) throw new ArgumentNullException();

                Cart cart = await _cartService.GetUserCartAsync(userId);

                if (cart is null) throw new NullReferenceException();

                return View(cart);
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

        [HttpPost]
        public async Task<IActionResult> RemoveGameFromCart(int? gameId, string userId)
        {
            try
            {
                if (gameId is null || userId is null) throw new ArgumentNullException();

                await _cartService.RemoveFromCartAsync(gameId, userId);

                return Ok();
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
        public async Task<IActionResult> IncreaseGameCount(int? gameId, string userId)
        {
            try
            {
                if (gameId is null || userId is null) throw new ArgumentNullException();

                await _cartService.IncreaseGameCountAsync(gameId, userId);

                return Ok();
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
        public async Task<IActionResult> DecreaseGameCount(int? gameId, string userId)
        {
            try
            {
                if (gameId is null || userId is null) throw new ArgumentNullException();

                await _cartService.DecreaseGameCountAsync(gameId, userId);

                return Ok();
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
        public async Task<IActionResult> ClearCart(string userId)
        {
            try
            {
                if(userId is null) throw new ArgumentNullException();

                await _cartService.ClearCartAsync(userId);

                return Ok();
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
        public async Task<IActionResult> Checkout(string userId, decimal total)
        {
            if (userId is null) throw new ArgumentNullException();

            AppUser user = await _userManager.FindByIdAsync(userId);
            await _cartService.ClearCartAsync(userId);

            TempData["Email"] = user.Email;

            string link = Url.Action(nameof(Index), "Shop", null, Request.Scheme, Request.Host.ToString());
            string subject = "Order Confirmation";
            string html;

            using (StreamReader reader = new StreamReader("wwwroot/assets/templates/OrderConfirmation.html"))
            {
                html = reader.ReadToEnd();
            }

            string fullName = user.FullName;
            string date = $"{DateTime.Now.ToString("MMMM dd, yyyy", new CultureInfo("en"))} at {DateTime.Now.ToString("hh:mm tt")}";

            html = html.Replace("{{fullName}}", fullName);
            html = html.Replace("{{total}}", total.ToString());
            html = html.Replace("{{date}}", date);
            html = html.Replace("{{link}}", link);

            _emailService.Send(user.Email, subject, html);

            return View();
        }
    }
}