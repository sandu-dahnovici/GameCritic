using AutoMapper;
using GameCritic.Domain.Entities;
using GameCritic.Application.Common.Dtos.Award;

namespace GameCritic.Application.Profiles
{
    public class AwardProfile : Profile
    {
        public AwardProfile()
        {
            CreateMap<Award, AwardDto>()
                .ForMember(gdto => gdto.Games, c => c.MapFrom(g => g.GameAwards));
            CreateMap<Award, AwardListDto>();
        }
    }
}