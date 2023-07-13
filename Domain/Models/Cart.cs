using System;
using Domain.Common;

namespace Domain.Models
{
	public class Cart: BaseEntity
	{
		public string UserId { get; set; }
		public AppUser User { get; set; }
		public ICollection<CartGame> CartGames { get; set; }
	}
}