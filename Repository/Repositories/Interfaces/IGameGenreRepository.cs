using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface IGameGenreRepository: IRepository<GameGenre>
	{
        Task<IEnumerable<GameGenre>> GetAllByGameIdAsync(int? id);
    }
}