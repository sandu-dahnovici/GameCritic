using AutoMapper;
using GameCritic.Domain.Entities;
using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.App.Commands.Games;

namespace GameCritic.Application.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameDto>()
                .ForMember(gdto => gdto.Awards, c => c.MapFrom(g => g.GameAwards))
                .ForMember(gdto => gdto.Genres, c => c.MapFrom(g => g.GameGenres))
                .ForMember(gdto => gdto.Publisher, c => c.MapFrom(g => g.Publisher))
                .ReverseMap();

            CreateMap<Game, GameListDto>();
                
            CreateMap<CreateGameCommand, Game>();
            CreateMap<UpdateGameCommand, Game>();
        }
    }
}
