using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IBlogAuthorService
	{
        Task<IEnumerable<BlogAuthor>> GetAllAsync();
        Task<BlogAuthor> GetByIdAsync(int? id);
        Task CreateAsync(BlogAuthor blogAuthor);
        Task UpdateAsync(BlogAuthor blogAuthor);
        Task DeleteAsync(BlogAuthor blogAuthor);
    }
}