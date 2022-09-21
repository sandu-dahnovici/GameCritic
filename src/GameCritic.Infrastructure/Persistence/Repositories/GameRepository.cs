using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace GameCritic.Infrastructure.Persistence.Repositories
{
    public class GameRepository :  GenericRepository<Game>, IGameRepository
    {
        private readonly GameCriticDbContext _dbContext;
        public GameRepository(GameCriticDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Game> GetGame(Expression<Func<Game, bool>> expression)
        {
            IQueryable<Game> games = _dbContext.Set<Game>();

            games = games
                .Include(g => g.Publisher)
                .Include(g => g.GameAwards)
                .ThenInclude(ga => ga.Award);

            return await games.FirstOrDefaultAsync(expression);
        }

        
    }
}
