using GameCritic.Domain.Entities;
using GameCritic.Domain.Auth;

namespace GameCritic.Application.Common.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAwardRepository AwardRepository { get; }
        IGameRepository GameRepository { get; }
        IGenericRepository<GameAward> GameAwardRepository { get; }
        IGenericRepository<GameGenre> GameGenreRepository { get; }
        IGenreRepository GenreRepository { get; }
        IGenericRepository<Publisher> PublisherRepository { get; }
        IReviewRepository ReviewRepository { get; }
        Task SaveAsync();
    }
}
