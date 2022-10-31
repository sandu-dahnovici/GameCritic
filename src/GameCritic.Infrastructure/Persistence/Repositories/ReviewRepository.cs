using AutoMapper;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameCritic.Infrastructure.Persistence.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        private readonly GameCriticDbContext _dbContext;

        public ReviewRepository(GameCriticDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
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

        public async Task<IList<Review>> GetReviewsByGameId(int id)
        {
            IQueryable<Review> reviews = _dbContext.Set<Review>();

            reviews = reviews.Include(r => r.Game)
                .Include(r => r.User)
                .Where(r => r.GameId == id);

            return await reviews.ToListAsync();
        }
    }
}
