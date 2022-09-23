using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.Common.Dtos.GameAward;
using GameCritic.Domain.Entities;
using MediatR;

namespace GameCritic.Application.App.Commands.Games
{
    public class CreateGameCommand : IRequest<GameDto>
    {
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Summary { get; set; }

        public string? ImageName { get; set; }

        public decimal Price { get; set; }

        public int? Playtime { get; set; }

        public int PublisherId { get; set; }

        public IList<int> GenresId { get; set; }

        public IList<CreateGameAwardDto> GameAwards { get; set; }
    }
}
