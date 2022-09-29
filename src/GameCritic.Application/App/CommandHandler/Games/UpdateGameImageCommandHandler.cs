using AutoMapper;
using GameCritic.Application.App.Commands.Games;
using GameCritic.Application.Common.Dtos.Game;
using System.Net;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.Common.Interfaces.Services;
using GameCritic.Domain.Entities;
using MediatR;

namespace GameCritic.Application.App.CommandHandler.Games
{
    public class UpdateGameImageCommandHandler : IRequestHandler<UpdateGameImageCommand,string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;

        public UpdateGameImageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IBlobService blobService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blobService = blobService;
        }

        public async Task<string> Handle(UpdateGameImageCommand request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.GetGame(g => g.Id == request.Id);

            if (game == null)
                throw new ResponseException(HttpStatusCode.NotFound, "Game was not found");

            if (game.ImageName != null)
                await _blobService.DeleteBlob(game.ImageName);

            game.ImageName = await _blobService.UploadBlob(request.Image);

            _unitOfWork.GameRepository.UpdateImage(game);

            await _unitOfWork.SaveAsync();

            return game.ImageName;
        }
    }
}
