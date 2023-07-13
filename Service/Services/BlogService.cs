using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepo;

        public BlogService(IBlogRepository blogRepo)
        {
            _blogRepo = blogRepo;
        }



        public async Task<IEnumerable<Blog>> GetAllWithIncludesAsync() => await _blogRepo.GetAllAsync(b => b.BlogImages, b => b.BlogAuthor);
        
        public async Task<Blog> GetByIdWithIncludesAsync(int? id) => await _blogRepo.GetByIdAsync(id, b => b.BlogImages, b => b.BlogAuthor);

        public async Task CreateAsync(Blog blog)
        {
            if (blog is null) throw new ArgumentNullException();

            await _blogRepo.CreateAsync(blog);
        }

        public async Task UpdateAsync(Blog blog)
        {
            if (blog is null) throw new ArgumentNullException();

            await _blogRepo.UpdateAsync(blog);
        }

        public async Task DeleteAsync(Blog blog)
        {
            if (blog is null) throw new ArgumentNullException();

            await _blogRepo.DeleteAsync(blog);
        }

        public async Task<IEnumerable<Blog>> GetPaginatedDatasAsync(int page, int take)
        {
            IEnumerable<Blog> blogs = await _blogRepo.GetAllAsync(b => b.BlogImages, b => b.BlogAuthor);

            return blogs.Skip(page * take - take).Take(take);
        }

        public async Task<int> GetCountAsync() => await _blogRepo.GetCountAsync();

        public async Task<IEnumerable<Blog>> GetByNameWithIncludesAsync(string searchText)
        {
            if (searchText is null) throw new ArgumentNullException();

            return await _blogRepo.SearchByNameAsync(searchText);
        }
    }
}