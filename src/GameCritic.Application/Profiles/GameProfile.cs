using AutoMapper;
using GameCritic.Domain.Entities;
using GameCritic.Application.App.Dtos;

namespace GameCritic.Application.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameDto>()
                .ForMember(g => g.PublisherId, p => p.MapFrom(z => z.PublisherId));
        }
    }
}
