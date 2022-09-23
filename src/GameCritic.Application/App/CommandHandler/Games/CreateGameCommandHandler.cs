using AutoMapper;
using GameCritic.Application.App.Commands.Games;
using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Entities;
using MediatR;

namespace GameCritic.Application.App.CommandHandler.Games
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

            await _unitOfWork.SaveAsync();

            var gameDto = _mapper.Map<GameDto>(game);

            foreach (var genreId in request.GenresId)
            {
                var genre = _unitOfWork.GenreRepository.GetById(genreId);
                GameGenre gameGenre = new() { Game = game, Genre = await genre };
                _unitOfWork.GameGenreRepository.Add(gameGenre);
            }

            await _unitOfWork.SaveAsync();

            game = await _unitOfWork.GameRepository.GetGame(g => g.Id == game.Id);

            gameDto = _mapper.Map<GameDto>(game);

            return gameDto;
        }
    }
}
