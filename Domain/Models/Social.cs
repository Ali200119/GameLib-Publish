using System;
using Domain.Common;

namespace Domain.Models
{
	public class Social: BaseEntity
	{
		public string Name { get; set; }
		public string Icon { get; set; }
		public string Link { get; set; }
		public string Color { get; set; }
	}
}