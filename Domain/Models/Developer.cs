using System;
using Domain.Common;

namespace Domain.Models
{
	public class Developer: BaseEntity
	{
		public string Name { get; set; }
		public string Logo { get; set; }
	}
}