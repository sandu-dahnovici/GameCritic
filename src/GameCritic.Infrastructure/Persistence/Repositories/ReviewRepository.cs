using AutoMapper;
using GameCritic.Application.Common.Dtos.Review;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.Common.Models;
using GameCritic.Application.Extensions;
using GameCritic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameCritic.Infrastructure.Persistence.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        private readonly GameCriticDbContext _dbContext;
        private readonly IMapper _mapper;

        public ReviewRepository(GameCriticDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<ReviewUserListDto>> GetPagedReviewsByGameId(int id, PagedRequest pagedRequest)
        {
            IQueryable<Review> reviews = _dbContext.Set<Review>();

            reviews = reviews.Include(r => r.Game)
                .Include(r => r.User)
                .Where(r => r.GameId == id);

            return await reviews.CreatePaginatedResultAsync<Review, ReviewUserListDto>(pagedRequest, _mapper);
        }

        public async Task<PaginatedResult<ReviewGameListDto>> GetPagedReviewsByUserId(int id, PagedRequest pagedRequest)
        {
            IQueryable<Review> reviews = _dbContext.Set<Review>();

            reviews = reviews.Include(r => r.Game)
                .Include(r => r.User)
                .Where(r => r.UserId == id);

            return await reviews.CreatePaginatedResultAsync<Review, ReviewGameListDto>(pagedRequest, _mapper);
        }

        public async Task<IList<Review>> GetReviewsByGameId(int id)
        {
            IQueryable<Review> reviews = _dbContext.Set<Review>();

            reviews = reviews.Include(r => r.Game)
                .Include(r => r.User)
                .Where(r => r.GameId == id);

            return await reviews.ToListAsync();
        }

        public async Task<int> GetReviewIdByUserAndGameId(int gameId, int userId)
        {
            IQueryable<Review> reviews = _dbContext.Set<Review>();

            var review = await reviews.Include(r => r.Game)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.GameId == gameId && r.UserId == userId);
            if (review == null)
                return 0;
            return review.Id;
        }
    }
}
