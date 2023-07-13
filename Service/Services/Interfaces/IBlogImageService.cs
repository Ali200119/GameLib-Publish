using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IBlogImageService
	{
		Task<IEnumerable<BlogImage>> GetAllByBlogIdAsync(int? id);
        Task DeleteAsync(BlogImage blogImage);
	}
}