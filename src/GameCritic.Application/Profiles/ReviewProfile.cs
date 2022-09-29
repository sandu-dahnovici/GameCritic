using AutoMapper;
using GameCritic.Domain.Auth;
using GameCritic.Application.Common.Dtos.Review;
using GameCritic.Domain.Entities;

namespace GameCritic.Application.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, GameReviewDto>()
                .ForMember(r => r.User, c => c.MapFrom(u => u.User));
        }
    }
}