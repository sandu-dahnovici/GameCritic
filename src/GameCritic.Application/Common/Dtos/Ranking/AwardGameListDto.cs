using GameCritic.Application.Common.Dtos;
using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.Common.Dtos.Award;

namespace GameCritic.Application.Common.Dtos.Ranking
{
    public class AwardGameListDto
    {
        public int Id { get; set; }

        public int Rank { get; set; }

        public GameListDto Game { get; set; }
    }
}