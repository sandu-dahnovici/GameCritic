using GameCritic.Application.Common.Dtos.Genre;
using MediatR;

namespace GameCritic.Application.App.Queries.Genres
{
    public class GetAllGenresQuery : IRequest<IList<GenreListDto>>
    {
    }
}
