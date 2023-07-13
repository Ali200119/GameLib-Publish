using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IDeveloperService
	{
		Task<IEnumerable<Developer>> GetAllAsync();
		Task<Developer> GetByIdAsync(int? id);
		Task CreateAsync(Developer developer);
		Task UpdateAsync(Developer developer);
		Task DeleteAsync(Developer developer);
    }
}