using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class PlatformService: IPlatformService
	{
        private readonly IPlatformRepository _platformRepo;

        public PlatformService(IPlatformRepository platformRepo)
        {
            _platformRepo = platformRepo;
        }



        public async Task<IEnumerable<Platform>> GetAllAsync() => await _platformRepo.GetAllAsync();

        public async Task<Platform> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            return await _platformRepo.GetByIdAsync(id);
        }

        public async Task CreateAsync(Platform platform)
        {
            if(platform is null) throw new ArgumentNullException();

            await _platformRepo.CreateAsync(platform);
        }

        public async Task UpdateAsync(Platform platform)
        {
            if (platform is null) throw new ArgumentNullException();

            await _platformRepo.UpdateAsync(platform);
        }

        public async Task DeleteAsync(Platform platform)
        {
            if (platform is null) throw new ArgumentNullException();

            await _platformRepo.DeleteAsync(platform);
        }

        public async Task<IEnumerable<Platform>> GetAllWithIncludesAsync() => await _platformRepo.GetAllWithFullDataAsync();

        public async Task<IEnumerable<Game>> FilterGames(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            List<Game> games = new List<Game>();

            Platform platform = await _platformRepo.GetByIdWithFullDataAsync(id);

            if (platform is null) throw new NullReferenceException();

            foreach (var game in platform.GamePlatforms.Select(gp => gp.Game))
            {
                games.Add(game);
            }

            return games;
        }
    }
}