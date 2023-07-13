using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IGamePlatformService
	{
		Task<IEnumerable<GamePlatform>> GetAllByGameIdAsync(int? id);
		Task DeleteAsync(GamePlatform gamePlatform);
    }
}