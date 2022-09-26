using AutoMapper;
using GameCritic.Application.App.Commands.Games;
using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.Common.Interfaces.Services;
using GameCritic.Domain.Entities;
using MediatR;

namespace GameCritic.Application.App.CommandHandler.Games
{
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;

        public DeleteGameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.GetGame(g => g.Id == request.Id);

            if (game == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound,"This game cannot be found");

            if (game.ImageName != null)
                await _blobService.DeleteBlob(game.ImageName);

            await _unitOfWork.GameRepository.Delete(request.Id);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
