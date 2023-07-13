using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class SubscribeRepository : Repository<Subscribe>, ISubscribeRepository
    {
        public SubscribeRepository(AppDbContext context) : base(context)
        {
        }



        public async Task<bool> CheckIfEmailExistsAsync(string email)
        {
            if (email is null) throw new ArgumentNullException();

            Subscribe subscribe = await entities.FirstOrDefaultAsync(s => s.Email.Trim().ToLower() == email.Trim().ToLower());

            if (subscribe is not null) return true;

            return false;
        }
    }
}