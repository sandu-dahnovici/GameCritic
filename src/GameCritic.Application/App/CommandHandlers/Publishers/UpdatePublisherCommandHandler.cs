using AutoMapper;
using GameCritic.Application.App.Commands.Publishers;
using GameCritic.Application.Common.Dtos.Publisher;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Entities;
using MediatR;

namespace GameCritic.Application.App.CommandHandlers.Publishers
{
    public class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePublisherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
        {
            var publisher = await _unitOfWork.PublisherRepository.GetById(request.Id);

            if (publisher == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "No publisher found");

            _mapper.Map(request, publisher);

            _unitOfWork.PublisherRepository.Update(publisher);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
