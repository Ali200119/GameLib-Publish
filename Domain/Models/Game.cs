using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Models
{
	public class Game: BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string Developer { get; set; }
		public string Publisher { get; set; }
		public bool FavGame { get; set; } = false;
		public bool ForPlaySation { get; set; }
		public bool ForXbox { get; set; }
        public bool ForPC { get; set; }
        public DateTime ReleaseDate { get; set; }
		public string Trailer { get; set; }
		public ICollection<GameImage> GameImages { get; set; }
        public ICollection<GamePlatform> GamePlatforms { get; set; }
        public ICollection<GameGenre> GameGenres { get; set; }
		public ICollection<GameComment> GameComments { get; set; }
		public ICollection<CartGame> CartGames { get; set; }
	}
}