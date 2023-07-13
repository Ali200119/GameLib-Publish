using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Models
{
	public class GameComment: BaseEntity
	{
		[Required]
		public string Comment { get; set; }

		public int GameId { get; set; }
		public Game Game { get; set; }
		public string UserId { get; set; }
		public AppUser User { get; set; }
	}
}