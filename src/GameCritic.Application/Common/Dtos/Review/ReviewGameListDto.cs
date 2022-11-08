using GameCritic.Application.Common.Dtos.Game;

namespace GameCritic.Application.Common.Dtos.Review
{
    public class ReviewGameListDto
    {
        public int Id { get; set; }

        public int Mark { get; set; }

        public string? Comment { get; set; }

        public DateTime CreationDate { get; set; }

        public GameListDto Game { get; set; }
    }
}
