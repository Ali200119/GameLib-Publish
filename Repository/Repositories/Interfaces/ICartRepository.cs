using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface ICartRepository: IRepository<Cart>
	{
        Task<Cart> GetByUserIdAsync(string userId);
    }
}