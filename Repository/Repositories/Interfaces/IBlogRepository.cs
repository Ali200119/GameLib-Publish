using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface IBlogRepository: IRepository<Blog>
	{
        Task<IEnumerable<Blog>> SearchByNameAsync(string searchText);
    }
}