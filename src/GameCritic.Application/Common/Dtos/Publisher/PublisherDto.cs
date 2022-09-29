using GameCritic.Application.Common.Dtos.Game;

namespace GameCritic.Application.Common.Dtos.Publisher
{
    public class PublisherDto
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public int FoundationYear { get; set; }

        public string? WebsiteURL { get; set; }

        public int NumberOfEmployees { get; set; }

        public IList<GameListDto> Games { get; set; }
    }
}
