using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IPlatformService
	{
		Task<IEnumerable<Platform>> GetAllAsync();
		Task<Platform> GetByIdAsync(int? id);
		Task CreateAsync(Platform platform);
		Task UpdateAsync(Platform platform);
		Task DeleteAsync(Platform platform);
        Task<IEnumerable<Platform>> GetAllWithIncludesAsync();
		Task<IEnumerable<Game>> FilterGames(int? id);
	}
}