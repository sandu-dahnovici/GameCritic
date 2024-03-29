﻿using AutoMapper;
using GameCritic.Application.App.Commands.Games;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Entities;
using MediatR;

namespace GameCritic.Application.App.CommandHandlers.Games
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.GetGameById(request.Id);

            if (game == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "This game cannot be found");

            _mapper.Map(request, game);

            var genres = game.GameGenres.AsQueryable().Select(gg => gg.Genre).ToList();

            foreach (var genreId in request.GenresId)
            {
                var genre = await _unitOfWork.GenreRepository.GetById(genreId);
                if (!genres.Contains(genre))
                {
                    var gameGenre = new GameGenre() { Game = game, Genre = genre };
                    _unitOfWork.GameGenreRepository.Add(gameGenre);
                }
            }

            foreach (var genre in genres)
            {
                if (!request.GenresId.Contains(genre.Id))
                {
                    var gameGenreDelete = _unitOfWork.GameGenreRepository
                        .GetAll()
                        .SingleOrDefault(gg => gg.GenreId == genre.Id && gg.GameId == game.Id);

                    await _unitOfWork.GameGenreRepository.Delete(gameGenreDelete.Id);
                }
            }

            _unitOfWork.GameRepository.Update(game);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
