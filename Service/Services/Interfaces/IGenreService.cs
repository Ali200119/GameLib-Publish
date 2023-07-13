using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IGenreService
	{
		Task<IEnumerable<Genre>> GetAllAsync();
		Task<IEnumerable<Game>> FilterGames(int? id);
		Task<Genre> GetByIdAsync(int? id);
		Task CreateAsync(Genre genre);
        Task UpdateAsync(Genre genre);
        Task DeleteAsync(Genre genre);
    }
}