using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class SocialService: ISocialService
	{
        private readonly ISocialRepository _socialRepo;

        public SocialService(ISocialRepository socialRepo)
        {
            _socialRepo = socialRepo;
        }



        public async Task<IEnumerable<Social>> GetAllAsync() => await _socialRepo.GetAllAsync();

        public async Task<Social> GetByIdAsync(int? id) => await _socialRepo.GetByIdAsync(id);

        public async Task CreateAsync(Social social)
        {
            if (social is null) throw new ArgumentNullException();

            await _socialRepo.CreateAsync(social);
        }

        public async Task UpdateAsync(Social social)
        {
            if (social is null) throw new ArgumentNullException();

            await _socialRepo.UpdateAsync(social);
        }

        public async Task DeleteAsync(Social social)
        {
            if (social is null) throw new ArgumentNullException();

            await _socialRepo.DeleteAsync(social);
        }
    }
}