using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Genre> GetByIdWithFullDataAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            Genre genre = await entities.Include(g => g.GameGenres)
                                        .ThenInclude(gg => gg.Game)
                                        .ThenInclude(g => g.GameImages)
                                        .FirstOrDefaultAsync(g => g.Id == id);

            if (genre is null) throw new NullReferenceException();

            return genre;
        }
    }
}