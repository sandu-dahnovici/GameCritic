using GameCritic.Application.Common.Dtos.Review;
using GameCritic.Application.Common.Models;
using GameCritic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCritic.Application.Common.Interfaces.Repositories
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<PaginatedResult<ReviewGameListDto>> GetPagedReviewsByUserId(int id, PagedRequest pagedRequest);
        Task<PaginatedResult<ReviewUserListDto>> GetPagedReviewsByGameId(int id, PagedRequest pagedRequest);
        Task<Review> GetReviewIdByUserAndGameId(int gameId, int userId);
        public Task<IList<Review>> GetReviewsByGameId(int id);
        public Task<IList<Review>> GetReviewsByUserId(int id);
    }
}
