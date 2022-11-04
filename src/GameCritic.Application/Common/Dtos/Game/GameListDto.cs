namespace GameCritic.Application.Common.Dtos.Game
{
    public class GameListDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string? ImageName { get; set; }

        public decimal Price { get; set; }

        public double? Score { get; set; }
    }
}
