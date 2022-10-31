using GameCritic.Application.Common.Dtos.Publisher;
using GameCritic.Application.Common.Models;
using MediatR;

namespace GameCritic.Application.App.Queries.Publishers
{
    public class GetPublishersPagedQuery : IRequest<PaginatedResult<PublisherListDto>>
    {
        public PagedRequest PagedRequest { get; set; }
    }

}
