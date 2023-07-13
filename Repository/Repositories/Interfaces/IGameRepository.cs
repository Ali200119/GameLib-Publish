using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface IGameRepository: IRepository<Game>
	{
		Task<Game> GetByIdWithFullDataAsync(int? id);
		Task<IEnumerable<Game>> SearchByNameAsync(string searchText);
		Task<IEnumerable<Game>> Sort(string pattern);
	}
}