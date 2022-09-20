using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameCritic.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly GameCriticDbContext _dbContext;
        private readonly DbSet<TEntity> _entities;

        public GenericRepository(GameCriticDbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _entities.Find(id);
            if(entity == null)
            {
                throw new Exception($"{typeof(TEntity)} with id { id } is not found");
            }

            _entities.Remove(entity);
        }

        public List<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _entities.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
