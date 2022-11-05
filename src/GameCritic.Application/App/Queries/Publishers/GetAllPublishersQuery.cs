using GameCritic.Application.Common.Dtos.Publisher;
using MediatR;

namespace GameCritic.Application.App.Queries.Publishers
{
    public class GetAllPublishersQuery : IRequest<IList<PublisherListDto>>
    {
    }
}
