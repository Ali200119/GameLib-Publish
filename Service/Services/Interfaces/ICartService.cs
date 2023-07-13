using System;
using Domain.Models;
using Service.ViewModels;

namespace Service.Services.Interfaces
{
	public interface ICartService
	{
        Task CreateUserCartAsync(string userId);
        Task AddToCartAsync(string userId, CartGame existedGame, int? gameId, string platform);
        Task<Cart> GetUserCartAsync(string userId);
        Task RemoveFromCartAsync(int? gameId, string userId);
        Task IncreaseGameCountAsync(int? gameId, string userId);
        Task DecreaseGameCountAsync(int? gameId, string userId);
        Task ClearCartAsync(string userId);
        Task<int> CheckCartAsync(string userId);
    }
}