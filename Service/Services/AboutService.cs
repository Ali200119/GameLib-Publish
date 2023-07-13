using System;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class AboutService: IAboutService
	{
        private readonly IAboutRepository _aboutRepo;

        public AboutService(IAboutRepository aboutRepo)
        {
            _aboutRepo = aboutRepo;
        }



        public async Task<IEnumerable<About>> GetAsync()
        {
            return await _aboutRepo.GetAllAsync();
        }

        public async Task UpdateAsync(About about)
        {
            if (about is null) throw new ArgumentNullException();

            await _aboutRepo.UpdateAsync(about);
        }
    }
}