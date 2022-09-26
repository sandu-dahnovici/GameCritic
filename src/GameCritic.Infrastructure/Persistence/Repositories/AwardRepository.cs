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

        public async Task<Award> GetAward(Expression<Func<Award, bool>> expression)
        {
            IQueryable<Award> awards = _dbContext.Set<Award>();

            awards = awards
                .Include(g => g.GameAwards)
                    .ThenInclude(gg => gg.Game)
                    .ThenInclude(ggg => ggg.Publisher);

            return await awards.FirstOrDefaultAsync(expression);
        }
    }
}
