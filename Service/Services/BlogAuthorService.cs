using System;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class BlogAuthorService: IBlogAuthorService
	{
		private readonly IBlogAuthorRepository _blogAuthorRepo;

        public BlogAuthorService(IBlogAuthorRepository blogAuthorRepo)
        {
            _blogAuthorRepo = blogAuthorRepo;
        }



        public async Task<IEnumerable<BlogAuthor>> GetAllAsync() => await _blogAuthorRepo.GetAllAsync();

        public async Task<BlogAuthor> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            return await _blogAuthorRepo.GetByIdAsync(id);
        }

        public async Task CreateAsync(BlogAuthor blogAuthor)
        {
            if (blogAuthor is null) throw new ArgumentNullException();

            await _blogAuthorRepo.CreateAsync(blogAuthor);
        }

        public async Task UpdateAsync(BlogAuthor blogAuthor)
        {
            if (blogAuthor is null) throw new ArgumentNullException();

            await _blogAuthorRepo.UpdateAsync(blogAuthor);
        }

        public async Task DeleteAsync(BlogAuthor blogAuthor)
        {
            if (blogAuthor is null) throw new ArgumentNullException();

            await _blogAuthorRepo.DeleteAsync(blogAuthor);
        }
    }
}