using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface ISubscribeRepository: IRepository<Subscribe>
	{
        Task<bool> CheckIfEmailExistsAsync(string email);
    }
}