using System;
using Domain.Models;
using Service.Helpers;

namespace Service.ViewModels
{
	public class BlogVM
	{
		public Dictionary<string, string> SectionHeaders { get; set; }
		public Paginate<Blog> PaginatedDatas { get; set; }
		public IEnumerable<Blog> Blogs { get; set; }
		public IEnumerable<Social> Socials { get; set; }
	}
}