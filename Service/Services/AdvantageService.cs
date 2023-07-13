using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class AdvantageService: IAdvantageService
	{
        private readonly IAdvantageRepository _advantageRepo;

        public AdvantageService(IAdvantageRepository advantageRepo)
        {
            _advantageRepo = advantageRepo;
        }



        public async Task<IEnumerable<Advantage>> GetAllAsync() => await _advantageRepo.GetAllAsync();

        public async Task<Advantage> GetByIdAsync(int? id) => await _advantageRepo.GetByIdAsync(id);

        public async Task CreateAsync(Advantage advantage)
        {
            if (advantage is null) throw new ArgumentNullException();

            await _advantageRepo.CreateAsync(advantage);
        }

        public async Task UpdateAsync(Advantage advantage)
        {
            if (advantage is null) throw new ArgumentNullException();

            await _advantageRepo.UpdateAsync(advantage);
        }

        public async Task DeleteAsync(Advantage advantage)
        {
            if (advantage is null) throw new ArgumentNullException();

            await _advantageRepo.DeleteAsync(advantage);
        }
    }
}