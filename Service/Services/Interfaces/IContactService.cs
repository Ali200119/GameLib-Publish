using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IContactService
	{
		Task<IEnumerable<Contact>> GetAllAsync();
		Task<Contact> GetByIdAsync(int? id);
        Task CreateAsync(Contact contact);
		Task DeleteAsync(Contact contact);
    }
}