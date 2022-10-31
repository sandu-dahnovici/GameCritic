using AutoMapper;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Entities;

namespace GameCritic.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameCriticDbContext _dbContext;
        private readonly IMapper _mapper;

        private IAwardRepository _awardRepository;
        private IGameRepository _gameRepository;
        private IGenericRepository<GameAward> _gameAwardRepository;
        private IGenericRepository<GameGenre> _gameGenreRepository;
        private IGenreRepository _genreRepository;
        private IGenericRepository<Publisher> _publisherRepository;
        private IReviewRepository _reviewRepository;

        public IAwardRepository AwardRepository
        {
            get
            {
                if (_awardRepository == null)
                    _awardRepository = new AwardRepository(_dbContext, _mapper);
                return _awardRepository;
            }
        }

        public IGameRepository GameRepository
        {
            get
            {
                if (_gameRepository == null)
                    _gameRepository = new GameRepository(_dbContext, _mapper);
                return _gameRepository;
            }
        }

        public IGenericRepository<GameAward> GameAwardRepository
        {
            get
            {
                if (_gameAwardRepository == null)
                    _gameAwardRepository = new GenericRepository<GameAward>(_dbContext, _mapper);
                return _gameAwardRepository;
            }
        }
        public IGenericRepository<GameGenre> GameGenreRepository
        {
            get
            {
                if (_gameGenreRepository == null)
                    _gameGenreRepository = new GenericRepository<GameGenre>(_dbContext, _mapper);
                return _gameGenreRepository;
            }
        }

        public IGenreRepository GenreRepository
        {
            get
            {
                if (_genreRepository == null)
                    _genreRepository = new GenreRepository(_dbContext, _mapper);
                return _genreRepository;
            }
        }

        public IGenericRepository<Publisher> PublisherRepository
        {
            get
            {
                if (_publisherRepository == null)
                    _publisherRepository = new GenericRepository<Publisher>(_dbContext, _mapper);
                return _publisherRepository;
            }
        }

        public IReviewRepository ReviewRepository
        {
            get
            {
                if (_reviewRepository == null)
                    _reviewRepository = new ReviewRepository(_dbContext, _mapper);
                return _reviewRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        private bool disposedValue;

        public UnitOfWork(GameCriticDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
