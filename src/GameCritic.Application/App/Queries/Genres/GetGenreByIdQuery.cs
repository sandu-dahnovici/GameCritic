using MediatR;
using GameCritic.Application.Common.Dtos.Genre;

namespace GameCritic.Application.App.Queries.Genres
{
    public class GetGenreByIdQuery : IRequest<GenreDto>
    {
        public int GenreId { get; set; }
    }
}
