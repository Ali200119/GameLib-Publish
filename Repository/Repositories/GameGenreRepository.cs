using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class GameGenreRepository : Repository<GameGenre>, IGameGenreRepository
    {
        public GameGenreRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<GameGenre>> GetAllByGameIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            return await entities.AsNoTracking().Where(gp => gp.GameId == id).ToListAsync();
        }
    }
}