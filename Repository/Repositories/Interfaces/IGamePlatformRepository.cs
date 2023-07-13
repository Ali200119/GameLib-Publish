using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface IGamePlatformRepository: IRepository<GamePlatform>
	{
		Task<IEnumerable<GamePlatform>> GetAllByGameIdAsync(int? id);
	}
}