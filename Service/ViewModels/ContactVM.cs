using System;
using Domain.Models;

namespace Service.ViewModels
{
	public class ContactVM
	{
		public Dictionary<string, string> SectionHeaders { get; set; }
		public IEnumerable<Social> Socials { get; set; }
		public Contact Contact { get; set; }
	}
}