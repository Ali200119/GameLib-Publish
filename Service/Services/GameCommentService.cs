using System;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class GameCommentService: IGameCommentService
	{
		private readonly IGameCommentRepository _gameCommentRepo;

        public GameCommentService(IGameCommentRepository gameCommentRepo)
        {
            _gameCommentRepo = gameCommentRepo;
        }



        public async Task<IEnumerable<GameComment>> GetAllAsync(int? gameId)
        {
            if (gameId is null) throw new ArgumentNullException();

            IEnumerable<GameComment> gameComment = await _gameCommentRepo.GetAllAsync(gc => gc.User);

            return gameComment.Where(gc => gc.GameId == gameId);
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            GameComment gameComment = await _gameCommentRepo.GetByIdAsync(id);

            if (gameComment is null) throw new NullReferenceException();

            await _gameCommentRepo.DeleteAsync(gameComment);
        }

        public async Task CreateAsync(GameComment gameComment)
        {
            if (gameComment is null) throw new ArgumentNullException();

            await _gameCommentRepo.CreateAsync(gameComment);
        }
    }
}