using System.Collections.Generic;

namespace GameCritic.Domain.Entities
{
    public class Award : BaseEntity
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public ICollection<GameAward> GameAwards { get; set; }
    }
}
