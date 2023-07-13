using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IGameImageService
	{
        Task<IEnumerable<GameImage>> GetAllByGameIdAsync(int? id);
        Task DeleteAsync(GameImage gameImage);
    }
}