using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IGameService
	{
		Task<IEnumerable<Game>> GetAllWithIncludesAsync();
		Task<Game> GetByIdWithIncludesAsync(int? id);
		Task<IEnumerable<Game>> GetByNameWithIncludesAsync(string searchText);
		Task<IEnumerable<Game>> Sort(string pattern);
		Task CreateAsync(Game game);
        Task UpdateAsync(Game game);
        Task DeleteAsync(Game game);
    }
}