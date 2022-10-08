using AutoMapper;
using GameCritic.Application.App.Commands.Publishers;
using GameCritic.Application.Common.Dtos.Publisher;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Entities;
using MediatR;

namespace GameCritic.Application.App.CommandHandlers.Publishers
{
    public class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePublisherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
        {
            var publisher = await _unitOfWork.PublisherRepository.GetById(request.Id);

            if (publisher == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "No publisher found");

            await _unitOfWork.PublisherRepository.Delete(publisher.Id);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
