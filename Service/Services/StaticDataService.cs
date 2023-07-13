using System;
using System.Collections.Generic;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class StaticDataService : IStaticDataService
    {
        private readonly ISettingRepository _settingRepo;
        private readonly ISectionHeaderRepository _sectionHeaderRepo;

        public StaticDataService(ISettingRepository settingRepo, ISectionHeaderRepository sectionHeaderRepo)
        {
            _settingRepo = settingRepo;
            _sectionHeaderRepo = sectionHeaderRepo;
        }



        public Dictionary<string, string> GetAllSettings() => _settingRepo.GetAllDictionary();

        public Dictionary<string, string> GetAllSectionHeaders() => _sectionHeaderRepo.GetAllDictionary();
    }
}