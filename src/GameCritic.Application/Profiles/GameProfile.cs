using AutoMapper;
using GameCritic.Domain.Entities;
using GameCritic.Application.App.Dtos.Game;

namespace GameCritic.Application.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameDto>()
                .ForMember(gdto => gdto.Awards, c => c.MapFrom(g => g.GameAwards))
                .ForMember(gdto => gdto.Publisher, c => c.MapFrom(g => g.Publisher));
        }
    }
}
