using System;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class AboutRepository : Repository<About>, IAboutRepository
    {
        public AboutRepository(AppDbContext context) : base(context)
        {
        }
    }
}