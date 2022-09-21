namespace GameCritic.Application.App.Dtos.Publisher
{
    public class PublisherDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public int FoundationYear { get; set; }

        public string? WebsiteURL { get; set; }

        public int NumberOfEmployees { get; set; }
    }
}
