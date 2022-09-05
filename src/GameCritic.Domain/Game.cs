using System.Collections.Generic;

namespace GameCritic.Domain
{
    public class Game : BaseEntity
    {
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Summary { get; set; }

        public string? ImagePath { get; set; }

        public decimal Price { get; set; }

        public double Score { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        ICollection<Review> Reviews { get; set; }

        ICollection<GameAward> GameAwards { get; set; }

        ICollection<GameGenre> GameGenres { get; set; }
    }
}
