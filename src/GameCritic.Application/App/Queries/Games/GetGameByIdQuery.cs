using MediatR;
using GameCritic.Application.App.Dtos;

namespace GameCritic.Application.App.Queries.Games
{
    public class GetGameByIdQuery : IRequest<GameDto>
    {
        public int GameId { get; set; }
    }
}
