using GameCritic.Application.App.Dtos;
using GameCritic.Application.App.Dtos.Game;
using GameCritic.Application.App.Dtos.Award;
namespace GameCritic.Application.App.Dtos.GameAward
{
    public class GameAwardForGameDto
    {
        public int Id { get; set; }

        public int Rank { get; set; }

        public AwardForGameDto Award { get; set; }
    }
}