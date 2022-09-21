using AutoMapper;
using GameCritic.Domain.Entities;
using GameCritic.Application.App.Dtos.GameAward;

namespace GameCritic.Application.Profiles
{
    public class GameAwardProfile : Profile
    {
        public GameAwardProfile()
        {
            CreateMap<GameAward, GameAwardForGameDto>()
                .ForMember(ga => ga.Award , c => c.MapFrom(a => a.Award));
        }
    }
}