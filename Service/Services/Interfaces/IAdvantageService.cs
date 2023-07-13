using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IAdvantageService
	{
		Task<IEnumerable<Advantage>> GetAllAsync();
		Task<Advantage> GetByIdAsync(int? id);
		Task CreateAsync(Advantage advantage);
		Task UpdateAsync(Advantage advantage);
        Task DeleteAsync(Advantage advantage);
    }
}