using System;
using Domain.Models;

namespace Service.ViewModels
{
	public class ShopVM
	{
		public Dictionary<string, string> SectionHeaders { get; set; }
		public IEnumerable<Game> Games { get; set; }
		public IEnumerable<Platform> Platforms { get; set; }
		public IEnumerable<Genre> Genres { get; set; }
		public IEnumerable<Social> Socials { get; set; }
	}
}