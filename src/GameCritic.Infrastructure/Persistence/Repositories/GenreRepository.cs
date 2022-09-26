using AutoMapper;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace GameCritic.Infrastructure.Persistence.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly GameCriticDbContext _dbContext;

        public GenreRepository(GameCriticDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<Genre> GetGenre(Expression<Func<Genre, bool>> expression)
        {
            IQueryable<Genre> genres = _dbContext.Set<Genre>();

            genres = genres
                .Include(g => g.GameGenres)
                    .ThenInclude(gg => gg.Game)
                    .ThenInclude(ggg => ggg.Publisher);

            return await genres.FirstOrDefaultAsync(expression);
        }
    }
}
