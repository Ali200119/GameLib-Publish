﻿using System;
using Domain.Common;

namespace Domain.Models
{
	public class GamePlatform: BaseEntity
	{
		public int GameId { get; set; }
		public Game Game { get; set; }
		public int PlatformId { get; set; }
		public Platform Platform { get; set; }
	}
}