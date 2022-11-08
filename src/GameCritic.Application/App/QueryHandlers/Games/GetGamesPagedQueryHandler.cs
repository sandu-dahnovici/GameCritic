using MediatR;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.Common.Models;
using GameCritic.Application.App.Queries.Games;
using GameCritic.Application.Common.Dtos.Game;

namespace GameCritic.Application.App.QueryHandlers.Games
{
    public class GetGamesPagedQueryHandler : IRequestHandler<GetGamesPagedQuery, PaginatedResult<GameListDto>>
    {
        public readonly IUnitOfWork _unitOfWork;

        public GetGamesPagedQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResult<GameListDto>> Handle(GetGamesPagedQuery request, CancellationToken cancellationToken)
        {
            var pagedGamesDto = await _unitOfWork.GameRepository.GetPagedData<GameListDto>(request.PagedRequest);
            return pagedGamesDto;
        }
    }
}
