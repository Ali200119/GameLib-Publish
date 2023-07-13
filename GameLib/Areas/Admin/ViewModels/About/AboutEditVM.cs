using System;
using System.ComponentModel.DataAnnotations;

namespace GameLib.Areas.Admin.ViewModels.About
{
	public class AboutEditVM
	{
		public int Id { get; set; }

		public string? Image { get; set; }

		public IFormFile? Photo { get; set; }

		[Required]
		public string Title { get; set; }

        [Required]
        public string Description { get; set; }
	}
}