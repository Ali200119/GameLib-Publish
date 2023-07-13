using System;
using System.ComponentModel.DataAnnotations;

namespace GameLib.Areas.Admin.ViewModels.Advantage
{
	public class AdvantageEditVM
	{
		public int Id { get; set; }

		[Required]
		public string Icon { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Description { get; set; }
	}
}