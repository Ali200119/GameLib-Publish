using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface IPlatformRepository: IRepository<Platform>
	{
		Task<IEnumerable<Platform>> GetAllWithFullDataAsync();
        Task<Platform> GetByIdWithFullDataAsync(int? id);
    }
}