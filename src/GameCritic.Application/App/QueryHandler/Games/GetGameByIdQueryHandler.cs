using MediatR;
using AutoMapper;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.App.Queries.Games;
using GameCritic.Application.App.Dtos.Game;
using GameCritic.Application.App.Dtos.GameAward;

namespace GameCritic.Application.App.QueryHandler.Games
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
            var game = await _unitOfWork.GameRepository.GetGame(g => g.Id == request.GameId);
            var gameDto = _mapper.Map<GameDto>(game);
            return gameDto;
        }
    }
}
