using AutoMapper;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace GameCritic.Infrastructure.Persistence.Repositories
{
    public class AwardRepository : GenericRepository<Award>, IAwardRepository
    {
        private readonly GameCriticDbContext _dbContext;

        public AwardRepository(GameCriticDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Award>> GetAvailableAwardsByGameId(int id)
        {
            IQueryable<Award> awards = _dbContext.Set<Award>();

            awards = awards
                .Include(g => g.Rankings);

            awards = awards.Where(a => !a.Rankings.Any(r => r.GameId == id));

            return await awards.ToListAsync();
        }

        public async Task<IList<int>> GetAvailableRanksByAwardId(int id)
        {
            var ranks = Enumerable.Range(1, 50).ToList();

            IQueryable<Ranking> rankings = _dbContext.Set<Ranking>();

            var ocuppiedRankings = await rankings
                .Where(r => r.AwardId == id)
                .Select(r => r.Rank)
                .ToListAsync();

            return ranks.Except(ocuppiedRankings).ToList();
        }

        public async Task<Award> GetAward(Expression<Func<Award, bool>> expression)
        {
            IQueryable<Award> awards = _dbContext.Set<Award>();

            awards = awards
                .Include(g => g.Rankings)
                    .ThenInclude(gg => gg.Game);

            return await awards.FirstOrDefaultAsync(expression);
        }
    }
}
