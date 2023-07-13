using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class GenreService: IGenreService
	{
		private readonly IGenreRepository _genreRepo;

        public GenreService(IGenreRepository genreRepo)
        {
            _genreRepo = genreRepo;
        }



        public async Task<IEnumerable<Genre>> GetAllAsync() => await _genreRepo.GetAllAsync();

        public async Task<Genre> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            return await _genreRepo.GetByIdAsync(id);
        }

        public async Task CreateAsync(Genre genre)
        {
            if (genre is null) throw new ArgumentNullException();

            await _genreRepo.CreateAsync(genre);
        }

        public async Task UpdateAsync(Genre genre)
        {
            if (genre is null) throw new ArgumentNullException();

            await _genreRepo.UpdateAsync(genre);
        }

        public async Task DeleteAsync(Genre genre)
        {
            if (genre is null) throw new ArgumentNullException();

            await _genreRepo.DeleteAsync(genre);
        }

        public async Task<IEnumerable<Game>> FilterGames(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            List<Game> games = new List<Game>();

            Genre genre = await _genreRepo.GetByIdWithFullDataAsync(id);

            if (genre is null) throw new NullReferenceException();

            foreach (var game in genre.GameGenres.Select(gp => gp.Game))
            {
                games.Add(game);
            }

            return games;
        }
    }
}