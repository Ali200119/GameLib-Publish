using System;
using System.ComponentModel.DataAnnotations;

namespace GameLib.Areas.Admin.ViewModels.Genre
{
	public class GenreEditVM
    {
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}