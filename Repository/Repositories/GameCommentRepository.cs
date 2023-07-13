using System;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class GameCommentRepository : Repository<GameComment>, IGameCommentRepository
    {
        public GameCommentRepository(AppDbContext context) : base(context)
        {
        }
    }
}