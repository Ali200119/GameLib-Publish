using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BlogImageRepository : Repository<BlogImage>, IBlogImageRepository
    {
        public BlogImageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BlogImage>> GetAllByBlogIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            return await entities.AsNoTracking().Where(bi => bi.BlogId == id).ToListAsync();
        }
    }
}