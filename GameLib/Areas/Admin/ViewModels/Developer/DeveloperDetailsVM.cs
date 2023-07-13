using System;
namespace GameLib.Areas.Admin.ViewModels.Developer
{
	public class DeveloperDetailsVM
	{
		public string Logo { get; set; }
		public string Name { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}