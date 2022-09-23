namespace GameCritic.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<GameGenre> GameGenres { get; set; }

        
    }
}