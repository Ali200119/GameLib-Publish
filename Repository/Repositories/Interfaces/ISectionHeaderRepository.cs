using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface ISectionHeaderRepository: IRepository<SectionHeader>
	{
        Dictionary<string, string> GetAllDictionary();
    }
}