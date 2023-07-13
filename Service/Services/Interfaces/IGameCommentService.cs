using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IGameCommentService
	{
		Task CreateAsync(GameComment gameComment);
		Task DeleteAsync(int? id);
		Task<IEnumerable<GameComment>> GetAllAsync(int? gameId);
	}
}