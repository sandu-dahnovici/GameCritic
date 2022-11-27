using GameCritic.Application.Common.Dtos.Award;
using MediatR;

namespace GameCritic.Application.App.Queries.Rankings
{
    public class GetAvailableRanksByAwardIdQuery : IRequest<IList<int>>
    {
        public int AwardId { get; set; }
    }
}
