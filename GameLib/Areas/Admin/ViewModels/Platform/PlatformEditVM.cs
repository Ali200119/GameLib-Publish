using System;
using System.ComponentModel.DataAnnotations;

namespace GameLib.Areas.Admin.ViewModels.Platform
{
	public class PlatformEditVM
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}