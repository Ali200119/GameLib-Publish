using System;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class SectionHeaderRepository : Repository<SectionHeader>, ISectionHeaderRepository
    {
        public SectionHeaderRepository(AppDbContext context) : base(context)
        {
        }



        public Dictionary<string, string> GetAllDictionary() => entities.AsEnumerable()
                                                                        .ToDictionary(s => s.Key, s => s.Value);
    }
}