using AutoMapper;
using GameCritic.Application.App.Commands.Publishers;
using GameCritic.Application.Common.Dtos.Publisher;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Entities;
using MediatR;

namespace GameCritic.Application.App.CommandHandler.Publishers
{
    public class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommand, PublisherDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePublisherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PublisherDto> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
        {
            var publisher = _mapper.Map<Publisher>(request);

            _unitOfWork.PublisherRepository.Add(publisher);

            await _unitOfWork.SaveAsync();

            var publisherDto = _mapper.Map<PublisherDto>(publisher);

            return publisherDto;
        }
    }
}
