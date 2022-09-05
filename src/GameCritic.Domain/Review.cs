using GameCritic.Domain.Auth;
namespace GameCritic.Domain
{
    public class Review : BaseEntity
    {
        public DateTime CreationDate { get; set; }

        public int Mark { get; set; }

        public string? Comment { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
