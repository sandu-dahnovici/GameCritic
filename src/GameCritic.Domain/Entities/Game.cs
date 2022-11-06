using System.Collections.Generic;

namespace GameCritic.Domain.Entities
{
    public class Game : BaseEntity
    {
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Summary { get; set; }

        public string? ImageName { get; set; }

        public decimal Price { get; set; }

        public double? Playtime { get; set; }

        public double? Score { get; set; }

        public byte[] RowVersion { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<Review>? Reviews { get; set; }

        public ICollection<Ranking>? Rankings { get; set; }

        public ICollection<GameGenre> GameGenres { get; set; }
    }
}
