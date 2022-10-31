using GameCritic.Application.Common.Dtos;
using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.Common.Dtos.Award;

namespace GameCritic.Application.Common.Dtos.GameAward
{
    public class CreateGameAwardDto
    {
        public int Rank { get; set; }

        public int AwardId { get; set; }
    }
}