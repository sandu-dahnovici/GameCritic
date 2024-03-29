﻿using AutoMapper;
using GameCritic.Domain.Entities;
using GameCritic.Application.Common.Dtos.Ranking;
using GameCritic.Application.App.Commands.Rankings;

namespace GameCritic.Application.Profiles
{
    public class RankingProfile : Profile
    {
        public RankingProfile()
        {
            CreateMap<Ranking, GameAwardListDto>()
                .ForMember(ga => ga.Award, c => c.MapFrom(a => a.Award));
            CreateMap<Ranking, AwardGameListDto>()
                .ForMember(ga => ga.Game, c => c.MapFrom(g => g.Game));
            CreateMap<CreateRankingCommand, Ranking>().ReverseMap();
        }
    }
}