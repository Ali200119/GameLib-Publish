using System;
using System.ComponentModel.DataAnnotations;

namespace GameLib.Areas.Admin.ViewModels.Game
{
	public class GameEditVM
	{
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required, Display(Name = "Favorite Game")]
        public bool FavGame { get; set; }

        [Required, Display(Name = "Released on PlayStation")]
        public bool ForPlayStation { get; set; }

        [Required, Display(Name = "Released on Xbox")]
        public bool ForXbox { get; set; }

        [Required, Display(Name = "Released on PC")]
        public bool ForPC { get; set; }

        [Required, Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Trailer { get; set; }

        public List<string>? Images { get; set; }
        public List<IFormFile>? Photos { get; set; }

        [Required, Display(Name = "Platforms")]
        public List<int> GamePlatformIdies { get; set; } = new();

        [Required, Display(Name = "Genres")]
        public List<int> GameGenreIdies { get; set; } = new();
    }
}