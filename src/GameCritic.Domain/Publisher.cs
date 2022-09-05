namespace GameCritic.Domain
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public int FoundationYear { get; set; }

        public string WebsiteURL { get; set; }

        public int NumberOfEmployees { get; set; }

    }
}
