using AutoMapper;
using GameCritic.Application.App.Queries.Publishers;
using GameCritic.Application.Common.Dtos.Publisher;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using MediatR;

namespace GameCritic.Application.App.QueryHandlers.Publishers
{
    public class GetAllPublishersQueryHandler : IRequestHandler<GetAllPublishersQuery, IList<PublisherListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPublishersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<PublisherListDto>> Handle(GetAllPublishersQuery request, CancellationToken cancellationToken)
        {
            var publishers = _unitOfWork.PublisherRepository.GetAll();

            if (publishers == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NoContent, "No publishers available");

            List<PublisherListDto> publisherListDtos = new();
            foreach (var publisher in publishers)
            {
                publisherListDtos.Add(_mapper.Map<PublisherListDto>(publisher));
            }

            return publisherListDtos;
        }
    }
}
