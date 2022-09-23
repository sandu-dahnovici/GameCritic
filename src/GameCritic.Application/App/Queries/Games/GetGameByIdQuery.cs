using MediatR;
using GameCritic.Application.Common.Dtos.Game;

namespace GameCritic.Application.App.Queries.Games
{
    public class GetGameByIdQuery : IRequest<GameDto>
    {
        public int GameId { get; set; }
    }
}
