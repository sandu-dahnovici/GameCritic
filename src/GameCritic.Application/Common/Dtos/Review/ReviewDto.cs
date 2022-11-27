using GameCritic.Application.Common.Dtos.Game;

namespace GameCritic.Application.Common.Dtos.Review
{
    public class ReviewDto
    {
        public int Id { get; set; }

        public int Mark { get; set; }

        public string? Comment { get; set; }

        public DateTime CreationDate { get; set; }

        public int GameId { get; set; }

        public int UserId { get; set; }
    }
}