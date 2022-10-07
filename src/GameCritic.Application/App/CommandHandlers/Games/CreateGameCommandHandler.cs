using AutoMapper;
using GameCritic.Application.App.Commands.Games;
using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Entities;
using MediatR;

namespace GameCritic.Application.App.CommandHandlers.Games
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, GameDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GameDto> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = _mapper.Map<Game>(request);

            _unitOfWork.GameRepository.Add(game);

            foreach (var genreId in request.GenresId)
            {
                var genre = await _unitOfWork.GenreRepository.GetById(genreId);
                GameGenre gameGenre = new() { Game = game, Genre = genre };
                _unitOfWork.GameGenreRepository.Add(gameGenre);
            }

            await _unitOfWork.SaveAsync();

            var gameDto = _mapper.Map<GameDto>(game);

            return gameDto;
        }
    }
}
