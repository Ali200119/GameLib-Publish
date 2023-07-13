using System;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class GameGenreService: IGameGenreService
	{
		private readonly IGameGenreRepository _gameGenreRepo;

        public GameGenreService(IGameGenreRepository gameGenreRepo)
        {
            _gameGenreRepo = gameGenreRepo;
        }



        public async Task<IEnumerable<GameGenre>> GetAllByGameIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            return await _gameGenreRepo.GetAllByGameIdAsync(id);
        }

        public async Task DeleteAsync(GameGenre gameGenre)
        {
            if (gameGenre is null) throw new ArgumentNullException();

            await _gameGenreRepo.DeleteAsync(gameGenre);
        }
    }
}