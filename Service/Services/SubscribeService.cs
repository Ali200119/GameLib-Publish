using System;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class SubscribeService: ISubscribeService
	{
        private readonly ISubscribeRepository _subscribeRepo;

        public SubscribeService(ISubscribeRepository subscribeRepo)
        {
            _subscribeRepo = subscribeRepo;
        }


        public async Task<IEnumerable<Subscribe>> GetAllAsync() => await _subscribeRepo.GetAllAsync();

        public async Task<Subscribe> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            return await _subscribeRepo.GetByIdAsync(id);
        }

        public async Task DeleteAsync(Subscribe subscriber)
        {
            if (subscriber is null) throw new ArgumentNullException();

            await _subscribeRepo.DeleteAsync(subscriber);
        }

        public async Task<bool> Subscribe(string email)
        {
            if (email is null) throw new ArgumentNullException();

            bool isEmailExists = await _subscribeRepo.CheckIfEmailExistsAsync(email);

            if (!isEmailExists)
            {
                Subscribe subscriber = new Subscribe
                {
                    Email = email
                };

                await _subscribeRepo.CreateAsync(subscriber);

                return true;
            }

            return false;
        }
    }
}