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
        public Task<IList<Review>> GetReviewsByGameId(int id);
    }
}
