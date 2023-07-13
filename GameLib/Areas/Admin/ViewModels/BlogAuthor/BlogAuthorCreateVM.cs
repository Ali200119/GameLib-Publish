using System;
using System.ComponentModel.DataAnnotations;

namespace GameLib.Areas.Admin.ViewModels.BlogAuthor
{
	public class BlogAuthorCreateVM
	{
		[Required, Display(Name = "Full Name")]
		public string Name { get; set; }
	}
}