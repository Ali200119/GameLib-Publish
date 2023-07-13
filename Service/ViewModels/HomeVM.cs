using System;
using Domain.Models;

namespace Service.ViewModels
{
	public class HomeVM
	{
		public Dictionary<string, string> SectionHeaders { get; set; }
		public IEnumerable<Game> Games { get; set; }
		public IEnumerable<Blog> Blogs { get; set; }
		public IEnumerable<Developer> Developers { get; set; }
		public IEnumerable<Advantage> Advantages { get; set; }
		public Subscribe Subscribe { get; set; }
	}
}