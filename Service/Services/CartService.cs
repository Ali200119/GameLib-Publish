using System;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Domain.Models;
using Service.Services.Interfaces;
using Service.ViewModels;
using Repository.Repositories.Interfaces;

namespace Service.Services
{
	public class CartService: ICartService
	{
		private readonly ICartRepository _cartRepo;
        private readonly ICartGameRepository _cartGameRepo;

        public CartService(ICartRepository cartRepo,
                           ICartGameRepository cartGameRepo)
        {
            _cartRepo = cartRepo;
            _cartGameRepo = cartGameRepo;
        }



        public async Task AddToCartAsync(string userId, CartGame existedGame, int? gameId, string platform)
        {
            if (userId is null || gameId is null || platform is null) throw new ArgumentNullException();

            Cart cart = await GetCartByUserIdAsync(userId);

            if (cart is null) throw new NullReferenceException();

            if(existedGame is null)
            {
                await _cartGameRepo.CreateAsync(new CartGame { CartId = cart.Id, GameId = (int)gameId, Count = 1, Platform = platform});
            }

            else
            {
                existedGame.Count++;
                await _cartGameRepo.UpdateAsync(existedGame);
            }
        }

        public async Task CreateUserCartAsync(string userId)
        {
            if (userId is null) throw new ArgumentNullException();

            await _cartRepo.CreateAsync(new Cart { UserId = userId});
        }

        public async Task<Cart> GetUserCartAsync(string userId)
        {
            return await GetCartByUserIdAsync(userId);
        }

        public async Task RemoveFromCartAsync(int? gameId, string userId)
        {
            if (gameId is null || userId is null) throw new ArgumentNullException();

            Cart cart = await GetCartByUserIdAsync(userId);

            if (cart is null) throw new NullReferenceException();

            CartGame cartGame = cart.CartGames.FirstOrDefault(cg => cg.GameId == gameId);

            await _cartGameRepo.DeleteAsync(cartGame);
        }

        public async Task IncreaseGameCountAsync(int? gameId, string userId)
        {
            if (gameId is null || userId is null) throw new ArgumentNullException();

            Cart cart = await GetCartByUserIdAsync(userId);

            if (cart is null) throw new NullReferenceException();

            CartGame cartGame = cart.CartGames.FirstOrDefault(cg => cg.GameId == gameId);

            cartGame.Count++;

            await _cartGameRepo.UpdateAsync(cartGame);
        }

        public async Task DecreaseGameCountAsync(int? gameId, string userId)
        {
            if (gameId is null || userId is null) throw new ArgumentNullException();

            Cart cart = await GetCartByUserIdAsync(userId);

            if (cart is null) throw new NullReferenceException();

            CartGame cartGame = cart.CartGames.FirstOrDefault(cg => cg.GameId == gameId);

            if(cartGame.Count > 1)
            {
                cartGame.Count--;
                await _cartGameRepo.UpdateAsync(cartGame);
            }
        }

        public async Task ClearCartAsync(string userId)
        {
            if (userId is null) throw new ArgumentNullException();

            Cart cart = await GetCartByUserIdAsync(userId);

            if (cart is null) throw new NullReferenceException();

            foreach (var game in cart.CartGames)
            {
                await _cartGameRepo.DeleteAsync(game);
            }
        }

        public async Task<int> CheckCartAsync(string userId)
        {
            if (userId is null) throw new ArgumentNullException();

            Cart cart = await GetCartByUserIdAsync(userId);

            return cart.CartGames.Count();
        }



        private async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return await _cartRepo.GetByUserIdAsync(userId);
        }
    }
}