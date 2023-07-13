using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Domain.Models;
using GameLib.Areas.Admin.ViewModels.Blog;
using GameLib.Areas.Admin.ViewModels.Game;
using GameLib.Helpers.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;

namespace GameLib.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IWebHostEnvironment _env;
        private readonly IPlatformService _platformService;
        private readonly IGenreService _genreService;
        private readonly IGameImageService _gameImageService;
        private readonly IGamePlatformService _gamePlatformService;
        private readonly IGameGenreService _gameGenreService;

        public GameController(IGameService gameService,
                              IWebHostEnvironment env,
                              IPlatformService platformService,
                              IGenreService genreService,
                              IGameImageService gameImageService,
                              IGamePlatformService gamePlatformService,
                              IGameGenreService gameGenreService)
        {
            _gameService = gameService;
            _env = env;
            _platformService = platformService;
            _genreService = genreService;
            _gameImageService = gameImageService;
            _gamePlatformService = gamePlatformService;
            _gameGenreService = gameGenreService;
        }



        public async Task<IActionResult> Index()
        {
            IEnumerable<Game> games = await _gameService.GetAllWithIncludesAsync();

            List<GameListVM> model = new List<GameListVM>();

            foreach (var game in games)
            {
                model.Add(new GameListVM
                {
                    Id = game.Id,
                    MainImage = game.GameImages.FirstOrDefault(gi => gi.IsMain).Name,
                    Name = game.Name,
                    Developer = game.Developer
                });
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Platforms = await GetPlatformsAsync();
            ViewBag.Genres = await GetGenresAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameCreateVM model)
        {
            ViewBag.Platforms = await GetPlatformsAsync();
            ViewBag.Genres = await GetGenresAsync();

            if (!ModelState.IsValid) return View(model);

            foreach (var photo in model.Photos)
            {
                if (!photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photos", "File type must be image.");
                    return View(model);
                }
            }

            IEnumerable<Game> games = await _gameService.GetAllWithIncludesAsync();

            List<GameImage> gameImages = new List<GameImage>();

            foreach (var photo in model.Photos)
            {
                string fileName = photo.GenerateFileName();
                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/games", fileName);

                await photo.CreateLocalFileAsync(path);

                GameImage gameImage = new GameImage
                {
                    Name = fileName
                };

                gameImages.Add(gameImage);
            }

            List<GamePlatform> gamePlatforms = new List<GamePlatform>();

            foreach (var gamePlatformId in model.GamePlatformIdies)
            {
                gamePlatforms.Add(new GamePlatform
                {
                    PlatformId = gamePlatformId
                });
            }

            List<GameGenre> gameGenres = new List<GameGenre>();

            foreach (var gameGenreId in model.GameGenreIdies)
            {
                gameGenres.Add(new GameGenre
                {
                    GenreId = gameGenreId
                });
            }

            gameImages.FirstOrDefault().IsMain = true;

            if (model.FavGame)
            {
                Game favGame = games.FirstOrDefault(b => b.FavGame);

                favGame.FavGame = false;

                await _gameService.UpdateAsync(favGame);
            }

            decimal convertedPrice = decimal.Parse(model.Price.Replace(".", ","));

            Game newGame = new Game
            {
                Name = model.Name,
                Price = convertedPrice,
                Description = model.Description,
                Developer = model.Developer,
                Publisher = model.Publisher,
                FavGame = model.FavGame,
                ForPlaySation = model.ForPlayStation,
                ForXbox = model.ForXbox,
                ForPC = model.ForPC,
                ReleaseDate = model.ReleaseDate,
                Trailer = model.Trailer,
                GameImages = gameImages,
                GamePlatforms = gamePlatforms,
                GameGenres = gameGenres
            };

            await _gameService.CreateAsync(newGame);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            Game game = await _gameService.GetByIdWithIncludesAsync(id);

            if (game is null) throw new NullReferenceException();


            List<string> images = new List<string>();

            foreach (var image in game.GameImages)
            {
                images.Add(image.Name);
            }

            List<string> platforms = new List<string>();

            foreach (var platform in game.GamePlatforms.Select(gp => gp.Platform))
            {
                platforms.Add(platform.Name);
            }

            List<string> genres = new List<string>();

            foreach (var genre in game.GameGenres.Select(gp => gp.Genre))
            {
                genres.Add(genre.Name);
            }


            GameDetailsVM model = new GameDetailsVM
            {
                Name = game.Name,
                Description = game.Description,
                Price = game.Price.ToString(),
                Developer = game.Developer,
                Publisher = game.Publisher,
                FavGame = game.FavGame,
                ForPlayStation = game.ForPlaySation,
                ForXbox = game.ForXbox,
                ForPC = game.ForPC,
                Trailer = game.Trailer,
                Images = images,
                ReleaseDate = game.ReleaseDate,
                Platforms = platforms,
                Genres = genres,
                CreatedAt = game.CreatedAt,
                ModifiedAt = game.ModifiedAt
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Platforms = await GetPlatformsAsync();
            ViewBag.Genres = await GetGenresAsync();

            if (id is null) throw new ArgumentNullException();

            Game game = await _gameService.GetByIdWithIncludesAsync(id);

            if (game is null) throw new NullReferenceException();

            List<string> images = new List<string>();

            foreach (var image in game.GameImages)
            {
                images.Add(image.Name);
            }

            GameEditVM model = new GameEditVM
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                Price = game.Price.ToString(),
                Developer = game.Developer,
                Publisher = game.Publisher,
                FavGame = game.FavGame,
                ForPlayStation = game.ForPlaySation,
                ForXbox = game.ForXbox,
                ForPC = game.ForPC,
                GamePlatformIdies = game.GamePlatforms.Select(gp => gp.PlatformId).ToList(),
                GameGenreIdies = game.GameGenres.Select(gg => gg.GenreId).ToList(),
                Images = images,
                ReleaseDate = game.ReleaseDate,
                Trailer = game.Trailer
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GameEditVM model)
        {
            ViewBag.Platforms = await GetPlatformsAsync();
            ViewBag.Genres = await GetGenresAsync();

            Game game = await _gameService.GetByIdWithIncludesAsync(model.Id);

            if (game is null) throw new NullReferenceException();

            List<string> images = new List<string>();

            foreach (var image in game.GameImages)
            {
                images.Add(image.Name);
            }

            model.Images = images;

            if (!ModelState.IsValid) return View(model);

            List<GameImage> gameImages = new List<GameImage>();

            if (model.Photos is null)
            {
                foreach (var image in game.GameImages)
                {
                    gameImages.Add(image);
                }
            }

            else
            {
                foreach (var photo in model.Photos)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photos", "File type must be image.");
                        return View(model);
                    }
                }

                foreach (var photo in model.Photos)
                {
                    string fileName = photo.GenerateFileName();
                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/games", fileName);

                    await photo.CreateLocalFileAsync(path);

                    GameImage gameImage = new GameImage
                    {
                        GameId = model.Id,
                        Name = fileName
                    };

                    gameImages.Add(gameImage);
                }

                gameImages.FirstOrDefault().IsMain = true;

                IEnumerable<GameImage> dbGameImage = await _gameImageService.GetAllByGameIdAsync(model.Id);

                foreach (var image in dbGameImage)
                {
                    string oldPathImage = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/games", image.Name);

                    FileHelper.DeleteFileFromPath(oldPathImage);

                    await _gameImageService.DeleteAsync(image);
                }
            }

            IEnumerable<Game> games = await _gameService.GetAllWithIncludesAsync();

            if (model.FavGame)
            {
                Game favGame = games.FirstOrDefault(b => b.FavGame);

                favGame.FavGame = false;

                await _gameService.UpdateAsync(favGame);
            }

            decimal convertedPrice = decimal.Parse(model.Price.Replace(".", ","));

            IEnumerable<GamePlatform> dbGamePlatforms = await _gamePlatformService.GetAllByGameIdAsync(model.Id);

            foreach (var platform in dbGamePlatforms)
            {
                await _gamePlatformService.DeleteAsync(platform);
            }

            IEnumerable<GameGenre> dbGameGenre = await _gameGenreService.GetAllByGameIdAsync(model.Id);

            foreach (var genre in dbGameGenre)
            {
                await _gameGenreService.DeleteAsync(genre);
            }



            List<GamePlatform> gamePlatforms = new List<GamePlatform>();

            foreach (var gamePlatformId in model.GamePlatformIdies)
            {
                gamePlatforms.Add(new GamePlatform
                {
                    PlatformId = gamePlatformId
                });
            }

            List<GameGenre> gameGenres = new List<GameGenre>();

            foreach (var gameGenreId in model.GameGenreIdies)
            {
                gameGenres.Add(new GameGenre
                {
                    GenreId = gameGenreId
                });
            }

            Game updatedGame = new Game
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = convertedPrice,
                Developer = model.Developer,
                Publisher = model.Publisher,
                FavGame = model.FavGame,
                ForPlaySation = model.ForPlayStation,
                ForXbox = model.ForXbox,
                ForPC = model.ForPC,
                Trailer = model.Trailer,
                ReleaseDate = model.ReleaseDate,
                GameImages = gameImages,
                GamePlatforms = gamePlatforms,
                GameGenres = gameGenres,
                CreatedAt = game.CreatedAt,
                ModifiedAt = DateTime.Now
            };

            await _gameService.UpdateAsync(updatedGame);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            Game game = await _gameService.GetByIdWithIncludesAsync(id);

            if (game is null) throw new NullReferenceException();

            foreach (var image in game.GameImages)
            {
                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/games", image.Name);

                FileHelper.DeleteFileFromPath(path);
            }

            await _gameService.DeleteAsync(game);

            if (game.FavGame)
            {
                IEnumerable<Game> games = await _gameService.GetAllWithIncludesAsync();

                Game firstGame = games.FirstOrDefault();
                firstGame.FavGame = true;

                await _gameService.UpdateAsync(firstGame);
            }

            return RedirectToAction(nameof(Index));
        }



        private async Task<SelectList> GetPlatformsAsync()
        {
            IEnumerable<Platform> platforms = await _platformService.GetAllAsync();

            return new SelectList(platforms, "Id", "Name");
        }

        private async Task<SelectList> GetGenresAsync()
        {
            IEnumerable<Genre> genres = await _genreService.GetAllAsync();

            return new SelectList(genres, "Id", "Name");
        }
    }
}

