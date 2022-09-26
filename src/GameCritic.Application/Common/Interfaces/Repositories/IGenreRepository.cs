using GameCritic.Domain.Entities;
using System.Linq.Expressions;

namespace GameCritic.Application.Common.Interfaces.Repositories
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        Task<Genre> GetGenre(Expression<Func<Genre, bool>> expression);
    }
}
