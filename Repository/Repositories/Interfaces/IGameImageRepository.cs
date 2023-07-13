using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface IGameImageRepository: IRepository<GameImage>
	{
        Task<IEnumerable<GameImage>> GetAllByGameIdAsync(int? id);
    }
}