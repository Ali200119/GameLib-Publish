using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class PlatformRepository : Repository<Platform>, IPlatformRepository
    {
        public PlatformRepository(AppDbContext context) : base(context)
        {
        }



        public async Task<IEnumerable<Platform>> GetAllWithFullDataAsync() => await entities.Include(p => p.GamePlatforms)
                                                                                            .ThenInclude(gp => gp.Game)
                                                                                            .ToListAsync();

        public async Task<Platform> GetByIdWithFullDataAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            Platform platform = await entities.Include(p => p.GamePlatforms)
                                 .ThenInclude(gp => gp.Game)
                                 .ThenInclude(g => g.GameImages)
                                 .FirstOrDefaultAsync(p => p.Id == id);

            if (platform is null) throw new NullReferenceException();

            return platform;
        }
    }
}