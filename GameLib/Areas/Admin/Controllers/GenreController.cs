using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using GameLib.Areas.Admin.ViewModels.Genre;
using GameLib.Areas.Admin.ViewModels.Platform;
using GameLib.Helpers.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace GameLib.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }



        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<Genre> genres = await _genreService.GetAllAsync();

                List<GenreListVM> model = new List<GenreListVM>();

                foreach (var genre in genres)
                {
                    model.Add(new GenreListVM
                    {
                        Id = genre.Id,
                        Name = genre.Name
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

                Genre genre = await _genreService.GetByIdAsync(id);

                if (genre is null) throw new NullReferenceException();

                GenreDetailsVM model = new GenreDetailsVM
                {
                    Name = genre.Name,
                    CreatedAt = genre.CreatedAt,
                    ModifiedAt = genre.ModifiedAt
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
        public async Task<IActionResult> Create(GenreCreateVM model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                IEnumerable<Genre> genres = await _genreService.GetAllAsync();

                foreach (var genre in genres)
                {
                    if (genre.Name.Trim().ToLower() == model.Name.Trim().ToLower())
                    {
                        ModelState.AddModelError("Name", "Genre with this name is already exists.");
                        return View(model);
                    }
                }

                Genre newGenre = new Genre
                {
                    Name = model.Name
                };

                await _genreService.CreateAsync(newGenre);

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

                Genre genre = await _genreService.GetByIdAsync(id);

                if (genre is null) throw new NullReferenceException();

                GenreEditVM model = new GenreEditVM
                {
                    Id = genre.Id,
                    Name = genre.Name
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
        public async Task<IActionResult> Edit(GenreEditVM model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                IEnumerable<Genre> genres = await _genreService.GetAllAsync();

                foreach (var genre in genres)
                {
                    if (genre.Name.Trim().ToLower() == model.Name.Trim().ToLower() && genre.Id != model.Id)
                    {
                        ModelState.AddModelError("Name", "Genre with this name is already exists.");
                        return View(model);
                    }
                }

                Genre oldGenre = await _genreService.GetByIdAsync(model.Id);

                if (oldGenre is null) throw new NullReferenceException();

                Genre updatedGenre = new Genre
                {
                    Id = model.Id,
                    Name = model.Name,
                    CreatedAt = oldGenre.CreatedAt,
                    ModifiedAt = DateTime.Now
                };

                await _genreService.UpdateAsync(updatedGenre);

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

                Genre genre = await _genreService.GetByIdAsync(id);

                if (genre is null) throw new NullReferenceException();

                await _genreService.DeleteAsync(genre);

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