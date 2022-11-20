using GameCritic.Application.Common.Dtos.Award;
using MediatR;

namespace GameCritic.Application.App.Queries.Awards
{
    public class GetAvailableAwardsByGameIdQuery : IRequest<IList<AwardListDto>>
    {
        public int GameId { get; set; }
    }
}
