using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class CartRepository: Repository<Cart>, ICartRepository
    {
        public CartRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Cart> GetByUserIdAsync(string userId)
        {
            if (userId is null) throw new ArgumentNullException();

            return await entities.Include(c => c.User).Include(c => c.CartGames).ThenInclude(cg => cg.Game).ThenInclude(g => g.GameImages).FirstOrDefaultAsync(c => c.UserId == userId);
        }
    }
}