using AutoMapper;
using GameCritic.Domain.Entities;
using GameCritic.Application.Common.Dtos.Genre;

namespace GameCritic.Application.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreListDto>();
            CreateMap<Genre, GenreDto>()
                .ForMember(g => g.Games, c => c.MapFrom(gg => gg.GameGenres));
        }
    }
}