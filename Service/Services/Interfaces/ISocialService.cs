using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface ISocialService
	{
		Task<IEnumerable<Social>> GetAllAsync();
		Task<Social> GetByIdAsync(int? id);
		Task CreateAsync(Social social);
		Task UpdateAsync(Social social);
		Task DeleteAsync(Social social);
    }
}