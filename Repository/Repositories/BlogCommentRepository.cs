using System;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BlogCommentRepository : Repository<BlogComment>, IBlogCommentRepository
    {
        public BlogCommentRepository(AppDbContext context) : base(context)
        {
        }
    }
}