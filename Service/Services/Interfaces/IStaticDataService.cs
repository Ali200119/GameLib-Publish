using System;
namespace Service.Services.Interfaces
{
	public interface IStaticDataService
	{
		Dictionary<string, string> GetAllSettings();
		Dictionary<string, string> GetAllSectionHeaders();
    }
}