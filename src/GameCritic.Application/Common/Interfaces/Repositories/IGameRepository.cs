using GameCritic.Domain.Entities;
using System.Linq.Expressions;

namespace GameCritic.Application.Common.Interfaces.Repositories
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        Task<Game> GetGameById(int id);
        void UpdateImage(Game game);
        IList<Game> GetGames();
    }
}
