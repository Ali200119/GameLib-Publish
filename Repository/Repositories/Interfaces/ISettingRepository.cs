using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface ISettingRepository: IRepository<Setting>
	{
        Dictionary<string, string> GetAllDictionary();
    }
}