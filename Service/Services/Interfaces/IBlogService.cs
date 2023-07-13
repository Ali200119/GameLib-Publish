using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IBlogService
	{
		Task<IEnumerable<Blog>> GetAllWithIncludesAsync();
		Task<Blog> GetByIdWithIncludesAsync(int? id);
        Task CreateAsync(Blog blog);
        Task UpdateAsync(Blog blog);
        Task DeleteAsync(Blog blog);
        Task<IEnumerable<Blog>> GetPaginatedDatasAsync(int page, int take);
        Task<IEnumerable<Blog>> GetByNameWithIncludesAsync(string searchText);
        Task<int> GetCountAsync();
    }
}