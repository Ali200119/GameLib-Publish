using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IGameGenreService
	{
        Task<IEnumerable<GameGenre>> GetAllByGameIdAsync(int? id);
        Task DeleteAsync(GameGenre gameGenre);
    }
}