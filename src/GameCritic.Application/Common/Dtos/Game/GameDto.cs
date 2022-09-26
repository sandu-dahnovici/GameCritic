﻿using GameCritic.Application.Common.Dtos.Publisher;
using GameCritic.Application.Common.Dtos.Genre;
using GameCritic.Application.Common.Dtos.GameAward;
using GameCritic.Application.Common.Dtos.GameGenre;

namespace GameCritic.Application.Common.Dtos.Game
{
    public class GameDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Summary { get; set; }

        public string? ImageName { get; set; }

        public decimal Price { get; set; }

        public int Playtime { get; set; }

        public double? Score { get; set; }

        public ListPublisherDto Publisher { get; set; }

        public IList<ListGameAwardDto> Awards { get; set; }

        public IList<ListGenreDto> Genres { get; set; }
    }
}
