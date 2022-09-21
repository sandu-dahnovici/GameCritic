using GameCritic.Application.App.Dtos.Publisher;
using GameCritic.Application.App.Dtos.GameAward;

namespace GameCritic.Application.App.Dtos.Game
{
    public class GameDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Summary { get; set; }

        public string? ImageName { get; set; }

        public decimal Price { get; set; }

        public int Playtime { get; set; }

        public double? Score { get; set; }

        public PublisherDto Publisher { get; set; }

        public IEnumerable<GameAwardForGameDto> Awards { get; set; }
    }
}
