using GameCritic.Application.Common.Dtos.Publisher;
using MediatR;

namespace GameCritic.Application.App.Commands.Publishers
{
    public class CreatePublisherCommand : IRequest<PublisherDto>
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public int FoundationYear { get; set; }

        public string? WebsiteURL { get; set; }

        public int NumberOfEmployees { get; set; }
    }
}
