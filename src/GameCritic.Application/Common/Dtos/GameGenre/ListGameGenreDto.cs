using GameCritic.Application.Common.Dtos;
using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.Common.Dtos.Genre;

namespace GameCritic.Application.Common.Dtos.GameGenre
{
    public class ListGameGenreDto
    {
        public int Id { get; set; }

        public ListGenreDto Genre { get; set; }
    }
}