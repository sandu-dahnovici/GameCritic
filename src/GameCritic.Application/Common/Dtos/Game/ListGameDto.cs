namespace GameCritic.Application.Common.Dtos.Game
{
    public class ListGameDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; set; }

        public double? Score { get; set; }

        public string Publisher { get; set; }
    }
}
