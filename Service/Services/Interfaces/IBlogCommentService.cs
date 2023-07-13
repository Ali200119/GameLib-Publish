using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IBlogCommentService
	{
        Task CreateAsync(BlogComment blogComment);
        Task DeleteAsync(int? id);
        Task<IEnumerable<BlogComment>> GetAllAsync(int? blogId);
    }
}