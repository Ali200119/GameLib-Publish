using System;
using System.ComponentModel.DataAnnotations;

namespace GameLib.Areas.Admin.ViewModels.Social
{
	public class SocialCreateVM
	{
		[Required]
		public string Name { get; set; }

        [Required]
        public string Icon { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public string Color { get; set; }
	}
}