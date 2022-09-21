using GameCritic.Domain.Entities;
using GameCritic.Domain.Auth;

namespace GameCritic.Application.Common.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Award> AwardRepository { get; }
        IGameRepository GameRepository { get; }
        IGenericRepository<GameAward> GameAwardRepository { get; }
        IGenericRepository<GameGenre> GameGenreRepository { get; }
        IGenericRepository<Genre> GenreRepository { get; }
        IGenericRepository<Publisher> PublisherRepository { get; }
        IGenericRepository<Review> ReviewRepository { get; }
        Task SaveAsync();
    }
}
