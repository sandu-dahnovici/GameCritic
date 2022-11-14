using AutoMapper;
using GameCritic.Application.App.Commands.Games;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.Common.Interfaces.Services;
using MediatR;
using System.Net;


namespace GameCritic.Application.App.CommandHandlers.Games
{
    public class DeleteGameImageCommandHandler : IRequestHandler<DeleteGameImageCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;

        public DeleteGameImageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IBlobService blobService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blobService = blobService;
        }

        public async Task<Unit> Handle(DeleteGameImageCommand request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.GetGameById(request.Id);

            if (game == null)
                throw new HttpResponseException(HttpStatusCode.NotFound, "Game was not found");

            if (game.ImageName != null)
                await _blobService.DeleteBlob(game.ImageName);

            game.ImageName = null;

            _unitOfWork.GameRepository.UpdateImage(game);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
