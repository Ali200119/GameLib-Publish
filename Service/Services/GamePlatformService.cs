using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class GamePlatformService: IGamePlatformService
	{
        private readonly IGamePlatformRepository _gamePlatformRepo;

        public GamePlatformService(IGamePlatformRepository gamePlatformRepo)
        {
            _gamePlatformRepo = gamePlatformRepo;
        }



        public async Task<IEnumerable<GamePlatform>> GetAllByGameIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            return await _gamePlatformRepo.GetAllByGameIdAsync(id);
        }

        public async Task DeleteAsync(GamePlatform gamePlatform)
        {
            if (gamePlatform is null) throw new ArgumentNullException();

            await _gamePlatformRepo.DeleteAsync(gamePlatform);
        }
    }
}