using System;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class AdvantageRepository : Repository<Advantage>, IAdvantageRepository
    {
        public AdvantageRepository(AppDbContext context) : base(context)
        {
        }
    }
}