using System;
namespace GameLib.Areas.Admin.ViewModels.About
{
	public class AboutDetailsVM
	{
		public string Image { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}