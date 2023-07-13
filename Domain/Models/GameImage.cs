using System;
using Domain.Common;

namespace Domain.Models
{
	public class GameImage: BaseEntity
	{
		public string Name { get; set; }
		public bool IsMain { get; set; } = false;
		public int GameId { get; set; }
		public Game Game { get; set; }
	}
}