using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class GameImageRepository : Repository<GameImage>, IGameImageRepository
    {
        public GameImageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<GameImage>> GetAllByGameIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            return await entities.AsNoTracking().Where(gi => gi.GameId == id).ToListAsync();
        }
    }
}