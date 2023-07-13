using System;
using Domain.Common;

namespace Domain.Models
{
	public class Genre: BaseEntity
	{
		public string Name { get; set; }
		public ICollection<GameGenre> GameGenres { get; set; }
	}
}