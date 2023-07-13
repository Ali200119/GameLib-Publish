using System;
using Domain.Common;

namespace Domain.Models
{
	public class Advantage: BaseEntity
	{
		public string Icon { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}