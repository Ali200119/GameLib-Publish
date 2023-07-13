using System;
namespace GameLib.Areas.Admin.ViewModels.Game
{
	public class GameDetailsVM
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Price { get; set; }
		public string Developer { get; set; }
		public string Publisher { get; set; }
		public bool FavGame { get; set; }
		public bool ForPlayStation { get; set; }
		public bool ForXbox { get; set; }
		public bool ForPC { get; set; }
		public DateTime ReleaseDate { get; set; }
		public string Trailer { get; set; }
		public IEnumerable<string> Images { get; set; }
		public IEnumerable<string> Platforms { get; set; }
		public IEnumerable<string> Genres { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}