using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Game> GetByIdWithFullDataAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            Game game = await entities.AsNoTracking().Include(g => g.GameImages)
                                      .Include(g => g.GamePlatforms)
                                      .ThenInclude(gp => gp.Platform)
                                      .Include(g => g.GameGenres)
                                      .ThenInclude(gg => gg.Genre)
                                      .FirstOrDefaultAsync(g => g.Id == id);

            if (game is null) throw new NullReferenceException();

            return game;
        }

        public async Task<IEnumerable<Game>> SearchByNameAsync(string searchText)
        {
            if (searchText is null) throw new ArgumentNullException();

            return await entities.Where(g => g.Name.ToLower().Trim().Contains(searchText.ToLower().Trim()))
                                 .Include(g => g.GameImages)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Game>> Sort(string pattern)
        {
            if (pattern is null) throw new ArgumentNullException();

            IEnumerable<Game> games = await entities.Include(g => g.GameImages)
                                                    .Include(g => g.GamePlatforms)
                                                    .ThenInclude(gp => gp.Platform)
                                                    .Include(g => g.GameGenres)
                                                    .ThenInclude(gg => gg.Genre)
                                                    .ToListAsync();

            switch (pattern)
            {
                case "recent":
                    {
                        return games.OrderByDescending(g => g.ReleaseDate);
                    }

                case "low price to high":
                    {
                        return games.OrderBy(g => g.Price);
                    }

                case "high price to low":
                    {
                        return games.OrderByDescending(g => g.Price);
                    }

                default:
                    return games.OrderBy(g => g.Name);
            }
        }
    }
}