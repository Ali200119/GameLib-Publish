using System;
using Domain.Common;

namespace Domain.Models
{
	public class Blog: BaseEntity
	{
		public string Title { get; set; }
		public string Game { get; set; }
		public string ShortDescription { get; set; }
		public string Description { get; set; }
		public bool FavBlog { get; set; } = false;
		public ICollection<BlogImage> BlogImages { get; set; }
		public int BlogAuthorId { get; set; }
		public BlogAuthor BlogAuthor { get; set; }
		public ICollection<BlogComment> BlogComments { get; set; }
    }
}