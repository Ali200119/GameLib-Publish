using System;
using Domain.Models;

namespace Service.ViewModels
{
	public class BlogDetailsVM
	{
		public Dictionary<string, string> SectionHeaders { get; set; }
		public Blog Blog { get; set; }
		public IEnumerable<Blog> LatestBlogs { get; set; }
		public IEnumerable<Social> Socials { get; set; }
		public IEnumerable<BlogComment> Comments { get; set; }
		public BlogComment BlogComment { get; set; }
	}
}