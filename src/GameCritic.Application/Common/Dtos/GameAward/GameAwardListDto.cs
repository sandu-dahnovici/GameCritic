using GameCritic.Application.Common.Dtos;
using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.Common.Dtos.Award;

namespace GameCritic.Application.Common.Dtos.GameAward
{
    public class GameAwardListDto
    {
        public int Id { get; set; }

        public int Rank { get; set; }

        public AwardListDto Award { get; set; }
    }
}