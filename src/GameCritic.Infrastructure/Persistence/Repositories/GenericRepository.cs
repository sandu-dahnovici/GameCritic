using AutoMapper;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.Common.Models;
using GameCritic.Application.Extensions;
using GameCritic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameCritic.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly GameCriticDbContext _dbContext;
        private readonly DbSet<TEntity> _entities;
        private readonly IMapper _mapper;

        public GenericRepository(GameCriticDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<TEntity>();
            _mapper = mapper;
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity == null)
            {
                throw new Exception($"{typeof(TEntity)} with id {id} is not found");
            }

            _entities.Remove(entity);
        }

        public List<TEntity> GetAll()
        {
            return _entities.AsNoTracking().ToList();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<PaginatedResult<TDto>> GetPagedData<TDto>(PagedRequest pagedRequest) where TDto : class
        {
            return await _entities.CreatePaginatedResultAsync<TEntity, TDto>(pagedRequest, _mapper);
        }

        public async Task<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> entities = _entities;

            if (includeProperties != null)
                entities = includeProperties.Aggregate(entities,
                    (current, include) => current.Include(include));

            return await entities.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public void Update(TEntity entity)
        {
            _entities.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
