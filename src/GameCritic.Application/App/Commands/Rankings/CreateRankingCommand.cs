using MediatR;

namespace GameCritic.Application.App.Commands.Rankings
{
    public class CreateRankingCommand : IRequest<Unit>
    {
        public int Rank { get; set; }

        public int GameId { get; set; }

        public int AwardId { get; set; }
    }
}
