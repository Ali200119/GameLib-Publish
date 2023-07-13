using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace GameLib.Controllers
{
    public class SearchController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IBlogService _blogService;

        public SearchController(IGameService gameService, IBlogService blogService)
        {
            _gameService = gameService;
            _blogService = blogService;
        }



        [HttpGet]
        public async Task<IActionResult> SearchByGames(string searchText)
        {
            try
            {
                if (searchText is null) throw new ArgumentNullException();

                IEnumerable<Game> games = await _gameService.GetByNameWithIncludesAsync(searchText);

                ViewBag.SearchText = searchText;

                return View(games);
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
        public async Task<IActionResult> SearchByBlogs(string searchText)
        {
            try
            {
                if (searchText is null) throw new ArgumentNullException();

                IEnumerable<Blog> blogs = await _blogService.GetByNameWithIncludesAsync(searchText);

                ViewBag.SearchText = searchText;

                return View(blogs);
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