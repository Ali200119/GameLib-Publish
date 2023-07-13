using System;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class GameImageService: IGameImageService
	{
        private readonly IGameImageRepository _gameImageRepo;

        public GameImageService(IGameImageRepository gameImageRepo)
        {
            _gameImageRepo = gameImageRepo;
        }



        public async Task<IEnumerable<GameImage>> GetAllByGameIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            return await _gameImageRepo.GetAllByGameIdAsync(id);
        }

        public async Task DeleteAsync(GameImage gameImage)
        {
            if (gameImage is null) throw new ArgumentNullException();

            await _gameImageRepo.DeleteAsync(gameImage);
        }
    }
}