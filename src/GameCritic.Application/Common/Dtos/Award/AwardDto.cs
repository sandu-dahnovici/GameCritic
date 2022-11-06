using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.Common.Dtos.Ranking;

namespace GameCritic.Application.Common.Dtos.Award
{
    public class AwardDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public IEnumerable<AwardGameListDto> Games { get; set; }
    }
}
