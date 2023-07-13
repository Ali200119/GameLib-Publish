using System;
using System.ComponentModel.DataAnnotations;

namespace GameLib.Areas.Admin.ViewModels.Developer
{
	public class DeveloperCreateVM
	{
		[Required]
		public IFormFile Photo { get; set; }

		[Required]
		public string Name { get; set; }
	}
}