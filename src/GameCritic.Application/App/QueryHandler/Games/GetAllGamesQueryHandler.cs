using MediatR;
using AutoMapper;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.App.Queries.Games;
using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.Common.Exceptions;

namespace GameCritic.Application.App.QueryHandler.Games
{
    public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, IList<GameListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGamesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<GameListDto>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            var games = _unitOfWork.GameRepository.GetGames();

            if (games == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NoContent, "No games available");

            List<GameListDto> gameListDtos = new();
            foreach (var game in games)
            {
                gameListDtos.Add(_mapper.Map<GameListDto>(game));
            }

            return gameListDtos;
        }
    }
}
