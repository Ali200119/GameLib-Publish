using System;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class ContactService: IContactService
	{
        private readonly IContactRepository _contactRepo;

        public ContactService(IContactRepository contactRepo)
        {
            _contactRepo = contactRepo;
        }



        public async Task<IEnumerable<Contact>> GetAllAsync() => await _contactRepo.GetAllAsync();

        public async Task<Contact> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            return await _contactRepo.GetByIdAsync(id);
        }

        public async Task CreateAsync(Contact contact)
        {
            if (contact is null) throw new ArgumentNullException();

            await _contactRepo.CreateAsync(contact);
        }

        public async Task DeleteAsync(Contact contact)
        {
            if (contact is null) throw new ArgumentNullException();

            await _contactRepo.DeleteAsync(contact);
        }
    }
}