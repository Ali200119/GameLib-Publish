using System;
using Domain.Common;

namespace Domain.Models
{
	public class GameGenre: BaseEntity
	{
		public int GameId { get; set; }
		public Game Game { get; set; }
		public int GenreId { get; set; }
		public Genre Genre { get; set; }
	}
}