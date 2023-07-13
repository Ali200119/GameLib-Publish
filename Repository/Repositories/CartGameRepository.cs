using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class CartGameRepository : Repository<CartGame>, ICartGameRepository
    {
        public CartGameRepository(AppDbContext context) : base(context)
        {
        }
    }
}