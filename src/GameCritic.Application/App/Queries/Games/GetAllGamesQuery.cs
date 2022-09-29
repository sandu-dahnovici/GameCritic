using MediatR;
using GameCritic.Application.Common.Dtos.Game;

namespace GameCritic.Application.App.Queries.Games
{
    public class GetAllGamesQuery : IRequest<IList<GameListDto>>
    {

    }
}
