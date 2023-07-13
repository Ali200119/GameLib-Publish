using System;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class BlogImageService: IBlogImageService
	{
        private readonly IBlogImageRepository _blogImageRepo;

        public BlogImageService(IBlogImageRepository blogImageRepo)
        {
            _blogImageRepo = blogImageRepo;
        }



        public async Task<IEnumerable<BlogImage>> GetAllByBlogIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            return await _blogImageRepo.GetAllByBlogIdAsync(id);
        }

        public async Task DeleteAsync(BlogImage blogImage)
        {
            if (blogImage is null) throw new ArgumentNullException();

            await _blogImageRepo.DeleteAsync(blogImage);
        }
    }
}