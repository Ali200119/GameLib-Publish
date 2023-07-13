using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface ISubscribeService
	{
		Task<IEnumerable<Subscribe>> GetAllAsync();
		Task<Subscribe> GetByIdAsync(int? id);
		Task DeleteAsync(Subscribe subscriber);
        Task<bool> Subscribe(string email);
	}
}