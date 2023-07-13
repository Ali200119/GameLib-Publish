using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface IBlogImageRepository: IRepository<BlogImage>
	{
        Task<IEnumerable<BlogImage>> GetAllByBlogIdAsync(int? id);
    }
}