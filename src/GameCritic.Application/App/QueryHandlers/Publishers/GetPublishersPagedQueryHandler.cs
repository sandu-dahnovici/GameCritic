using MediatR;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.Common.Models;
using GameCritic.Application.App.Queries.Publishers;
using GameCritic.Application.Common.Dtos.Publisher;

namespace GameCritic.Application.App.QueryHandlers.Publishers
{
    public class GetPublishersPagedQueryHandler : IRequestHandler<GetPublishersPagedQuery, PaginatedResult<PublisherListDto>>
    {
        public readonly IUnitOfWork _unitOfWork;

        public GetPublishersPagedQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResult<PublisherListDto>> Handle(GetPublishersPagedQuery request, CancellationToken cancellationToken)
        {
            var pagedPublishersDto = await _unitOfWork.PublisherRepository.GetPagedData<PublisherListDto>(request.PagedRequest);
            return pagedPublishersDto;
        }
    }
}
