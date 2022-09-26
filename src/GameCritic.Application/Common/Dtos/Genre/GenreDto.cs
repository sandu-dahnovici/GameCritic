using GameCritic.Application.Common.Dtos.Game;

namespace GameCritic.Application.Common.Dtos.Genre
{
    public class GenreDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<ListGameDto> Games { get; set; }
    }
}
