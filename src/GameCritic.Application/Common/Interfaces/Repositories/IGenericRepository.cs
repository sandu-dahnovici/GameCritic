using GameCritic.Domain.Entities;
using System.Linq.Expressions;
using GameCritic.Application.Common.Models;

namespace GameCritic.Application.Common.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IList<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<PaginatedResult<TDto>> GetPagedData<TDto>(PagedRequest pagedRequest) where TDto : class;
        void Add(TEntity entity);
        void Update(TEntity entity);
        Task Delete(int id);
    }
}
