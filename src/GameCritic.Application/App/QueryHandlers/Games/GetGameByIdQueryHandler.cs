using MediatR;
using AutoMapper;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.App.Queries.Games;
using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.Common.Exceptions;

namespace GameCritic.Application.App.QueryHandlers.Games
{
    public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GameDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetGameByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GameDto> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.GetGameById(request.GameId);

            if (game == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "Not found game");

            var gameDto = _mapper.Map<GameDto>(game);
            return gameDto;
        }
    }
}
