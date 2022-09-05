namespace GameCritic.Domain
{
    public class GameAward : BaseEntity
    {
        public int GameId { get; set; }
        public Game Game { get; set; }

        public int AwardId { get; set; }
        public Award Award { get; set; }
    }
}
