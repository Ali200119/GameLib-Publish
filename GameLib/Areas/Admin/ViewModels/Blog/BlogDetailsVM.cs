using System;
namespace GameLib.Areas.Admin.ViewModels.Blog
{
	public class BlogDetailsVM
	{
        public IEnumerable<string> Images { get; set; }
		public string Title { get; set; }
        public string Game { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool FavBlog { get; set; }
        public string BlogAuthor { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}