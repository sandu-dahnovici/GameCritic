using MediatR;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.Common.Models;
using GameCritic.Application.App.Queries.Games;
using GameCritic.Application.Common.Dtos.Game;

namespace GameCritic.Application.App.QueryHandler.Games
{
    public class GetGamesPagedQueryHandler : IRequestHandler<GetGamesPagedQuery, PaginatedResult<ListGameDto>>
    {
        public readonly IGameRepository _gameRepository;

        public GetGamesPagedQueryHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<PaginatedResult<ListGameDto>> Handle(GetGamesPagedQuery request, CancellationToken cancellationToken)
        {
            var pagedGamesDto = await _gameRepository.GetPagedData<ListGameDto>(request.PagedRequest);
            return pagedGamesDto;
        }
    }
}
