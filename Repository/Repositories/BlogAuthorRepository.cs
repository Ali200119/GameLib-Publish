using System;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BlogAuthorRepository : Repository<BlogAuthor>, IBlogAuthorRepository
    {
        public BlogAuthorRepository(AppDbContext context) : base(context)
        {
        }
    }
}