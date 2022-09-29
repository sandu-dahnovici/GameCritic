using AutoMapper;
using GameCritic.Domain.Entities;
using GameCritic.Application.Common.Dtos.Award;

namespace GameCritic.Application.Profiles
{
    public class AwardProfile : Profile
    {
        public AwardProfile()
        {
            CreateMap<Award, AwardDto>();
            CreateMap<Award, AwardListDto>();
        }
    }
}