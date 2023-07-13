using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {
        }



        public async Task<IEnumerable<Blog>> SearchByNameAsync(string searchText)
        {
            if (searchText is null) throw new ArgumentNullException();

            return await entities.Where(g => g.Title.ToLower().Trim().Contains(searchText.ToLower().Trim()))
                                 .Include(g => g.BlogImages)
                                 .Include(g => g.BlogAuthor)
                                 .ToListAsync();
        }
    }
}