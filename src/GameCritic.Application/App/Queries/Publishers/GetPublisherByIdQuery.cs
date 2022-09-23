using MediatR;
using GameCritic.Application.Common.Dtos.Publisher;

namespace GameCritic.Application.App.Queries.Publishers
{
    public class GetPublisherByIdQuery : IRequest<PublisherDto>
    {
        public int PublisherId { get; set; }
    }
}
