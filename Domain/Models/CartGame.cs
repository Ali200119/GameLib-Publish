using System;
using Domain.Common;

namespace Domain.Models
{
	public class CartGame: BaseEntity
	{
		public int CartId { get; set; }
		public Cart Cart { get; set; }
		public int GameId { get; set; }
		public Game Game { get; set; }
		public int Count { get; set; }
		public string Platform { get; set; }
	}
}