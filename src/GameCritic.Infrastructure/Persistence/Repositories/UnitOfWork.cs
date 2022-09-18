using GameCritic.Application.Common.Interfaces;
using GameCritic.Domain.Entities;

namespace GameCritic.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameCriticDbContext _dbContext;

        private IGenericRepository<Award> _awardRepository;
        private IGenericRepository<Game> _gameRepository;
        private IGenericRepository<GameAward> _gameAwardRepository;
        private IGenericRepository<GameGenre> _gameGenreRepository;
        private IGenericRepository<Genre> _genreRepository;
        private IGenericRepository<Publisher> _publisherRepository;
        private IGenericRepository<Review> _reviewRepository;

        public IGenericRepository<Award> AwardRepository
        {
            get
            {
                if (_awardRepository == null)
                    _awardRepository = new GenericRepository<Award>(_dbContext);
                return _awardRepository;
            }
        }

        public IGenericRepository<Game> GameRepository
        {
            get
            {
                if (_gameRepository == null)
                    _gameRepository = new GenericRepository<Game>(_dbContext);
                return _gameRepository;
            }
        }

        public IGenericRepository<GameAward> GameAwardRepository
        {
            get
            {
                if (_gameAwardRepository == null)
                    _gameAwardRepository = new GenericRepository<GameAward>(_dbContext);
                return _gameAwardRepository;
            }
        }
        public IGenericRepository<GameGenre> GameGenreRepository
        {
            get
            {
                if (_gameGenreRepository == null)
                    _gameGenreRepository = new GenericRepository<GameGenre>(_dbContext);
                return _gameGenreRepository;
            }
        }

        public IGenericRepository<Genre> GenreRepository
        {
            get
            {
                if (_genreRepository == null)
                    _genreRepository = new GenericRepository<Genre>(_dbContext);
                return _genreRepository;
            }
        }

        public IGenericRepository<Publisher> PublisherRepository
        {
            get
            {
                if (_publisherRepository == null)
                    _publisherRepository = new GenericRepository<Publisher>(_dbContext);
                return _publisherRepository;
            }
        }

        public IGenericRepository<Review> ReviewRepository
        {
            get
            {
                if (_reviewRepository == null)
                    _reviewRepository = new GenericRepository<Review>(_dbContext);
                return _reviewRepository;
            }
        }

        private bool disposedValue;

        public UnitOfWork(GameCriticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
