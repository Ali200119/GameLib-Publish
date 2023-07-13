using System;
using System.ComponentModel.DataAnnotations;

namespace GameLib.Areas.Admin.ViewModels.Genre
{
	public class GenreCreateVM
    {
		[Required]
		public string Name { get; set; }
	}
}