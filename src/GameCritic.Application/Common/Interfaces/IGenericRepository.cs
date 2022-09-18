using GameCritic.Domain.Entities;

namespace GameCritic.Application.Common.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
