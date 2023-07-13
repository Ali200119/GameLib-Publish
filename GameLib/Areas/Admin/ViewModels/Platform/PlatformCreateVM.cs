using System;
using System.ComponentModel.DataAnnotations;

namespace GameLib.Areas.Admin.ViewModels.Platform
{
	public class PlatformCreateVM
	{
		[Required]
		public string Name { get; set; }
	}
}