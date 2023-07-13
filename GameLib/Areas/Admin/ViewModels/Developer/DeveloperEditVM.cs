using System;
using System.ComponentModel.DataAnnotations;

namespace GameLib.Areas.Admin.ViewModels.Developer
{
	public class DeveloperEditVM
	{
		public int Id { get; set; }
		public string? Logo { get; set; }
		public IFormFile? Photo { get; set; }

		[Required]
		public string Name { get; set; }
	}
}