using AutoMapper;
using GameCritic.Domain.Entities;
using GameCritic.Application.Common.Dtos.GameGenre;

namespace GameCritic.Application.Profiles
{
    public class GameGenreProfile : Profile
    {
        public GameGenreProfile()
        {
            CreateMap<GameGenre, ListGameGenreDto>()
                .ForMember(ga => ga.Genre, c => c.MapFrom(a => a.Genre));
        }
    }
}