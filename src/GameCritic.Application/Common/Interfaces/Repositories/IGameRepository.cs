using GameCritic.Domain.Entities;
using System.Linq.Expressions;

namespace GameCritic.Application.Common.Interfaces.Repositories
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        Task<Game> GetGame(Expression<Func<Game, bool>> expression);
    }
}
