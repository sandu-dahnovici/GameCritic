using GameCritic.Domain.Entities;
using System.Linq.Expressions;

namespace GameCritic.Application.Common.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        List<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includeProperties);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
