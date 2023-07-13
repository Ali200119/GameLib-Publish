using System;
namespace GameLib.Areas.Admin.ViewModels.Social
{
	public class SocialDetailsVM
	{
		public string Name { get; set; }
		public string Icon { get; set; }
		public string Link { get; set; }
		public string Color { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}