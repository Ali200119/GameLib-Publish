using System;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class SocialRepository : Repository<Social>, ISocialRepository
    {
        public SocialRepository(AppDbContext context) : base(context)
        {
        }
    }
}