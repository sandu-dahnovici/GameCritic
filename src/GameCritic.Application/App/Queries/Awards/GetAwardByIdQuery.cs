using MediatR;
using GameCritic.Application.Common.Dtos.Award;

namespace GameCritic.Application.App.Queries.Awards
{
    public class GetAwardByIdQuery : IRequest<AwardDto>
    {
        public int AwardId { get; set; }
    }
}