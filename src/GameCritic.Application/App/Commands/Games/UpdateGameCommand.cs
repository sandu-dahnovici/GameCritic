using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.Common.Dtos.GameAward;
using GameCritic.Domain.Entities;
using MediatR;

namespace GameCritic.Application.App.Commands.Games
{
    public class UpdateGameCommand : IRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Summary { get; set; }

        public decimal Price { get; set; }

        public double? Playtime { get; set; }

        public int PublisherId { get; set; }

        public IList<int> GenresId { get; set; }

        public IList<CreateGameAwardDto> GameAwards { get; set; }
    }
}
