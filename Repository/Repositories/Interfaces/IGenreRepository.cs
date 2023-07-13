using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface IGenreRepository: IRepository<Genre>
	{
		Task<Genre> GetByIdWithFullDataAsync(int? id);
	}
}