using System.Collections.Generic;

namespace GameCritic.Domain
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<GameGenre> GameGenres { get; set; }
    }
}