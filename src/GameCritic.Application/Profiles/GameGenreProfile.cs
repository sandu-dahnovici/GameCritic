using AutoMapper;
using GameCritic.Domain.Entities;
using GameCritic.Application.Common.Dtos.GameGenre;
using GameCritic.Application.Common.Dtos.Genre;
using GameCritic.Application.Common.Dtos.Game;

namespace GameCritic.Application.Profiles
{
    public class GameGenreProfile : Profile
    {
        public GameGenreProfile()
        {
            CreateMap<GameGenre, GameGenreListDto>()
                .ForMember(ga => ga.Genre, c => c.MapFrom(a => a.Genre));
            CreateMap<GameGenre, GenreListDto>()
                .ForMember(g => g.Id, c => c.MapFrom(gg => gg.GenreId))
                .ForMember(g => g.Name, c => c.MapFrom(gg => gg.Genre.Name));
            CreateMap<GameGenre, GameListDto>()
                .ForMember(g => g.Id, c => c.MapFrom(gg => gg.GameId))
                .ForMember(g => g.Price, c => c.MapFrom(gg => gg.Game.Price))
                .ForMember(g => g.ReleaseDate, c => c.MapFrom(gg => gg.Game.ReleaseDate))
                .ForMember(g => g.Score, c => c.MapFrom(gg => gg.Game.Score))
                .ForMember(g => g.Title, c => c.MapFrom(gg => gg.Game.Title));
        }
    }
}