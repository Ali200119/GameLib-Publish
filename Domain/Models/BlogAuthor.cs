using System;
using Domain.Common;

namespace Domain.Models
{
	public class BlogAuthor: BaseEntity
	{
		public string Name { get; set; }
		public ICollection<Blog> Blogs { get; set; }
	}
}