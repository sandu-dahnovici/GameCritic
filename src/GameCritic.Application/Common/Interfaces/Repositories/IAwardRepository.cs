using GameCritic.Application.Common.Dtos.Award;
using GameCritic.Domain.Entities;
using System.Linq.Expressions;

namespace GameCritic.Application.Common.Interfaces.Repositories
{
    public interface IAwardRepository : IGenericRepository<Award>
    {
        Task<Award> GetAward(Expression<Func<Award, bool>> expression);
        Task<IList<Award>> GetAvailableAwardsByGameId(int id);
    }
}
