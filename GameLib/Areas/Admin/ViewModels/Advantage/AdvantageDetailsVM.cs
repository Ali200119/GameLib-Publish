using System;
namespace GameLib.Areas.Admin.ViewModels.Advantage
{
	public class AdvantageDetailsVM
	{
		public string Icon { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}