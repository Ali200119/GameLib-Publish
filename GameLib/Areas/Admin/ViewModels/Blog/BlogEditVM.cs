using System;
using System.ComponentModel.DataAnnotations;

namespace GameLib.Areas.Admin.ViewModels.Blog
{
	public class BlogEditVM
	{
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Game { get; set; }

        [Required, Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Required]
        public string Description { get; set; }

        [Required, Display(Name = "Favorite Blog")]
        public bool FavBlog { get; set; }

		public List<string>? Images { get; set; }

		public List<IFormFile>? Photos { get; set; }

        [Required, Display(Name = "Blog Author")]
        public int BlogAuthorId { get; set; }
	}
}