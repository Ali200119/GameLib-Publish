using System;
using System.ComponentModel.DataAnnotations;

namespace GameLib.Areas.Admin.ViewModels.BlogAuthor
{
	public class BlogAuthorEditVM
	{
		public int Id { get; set; }

		[Required, Display(Name = "Full Name")]
		public string Name { get; set; }
	}
}