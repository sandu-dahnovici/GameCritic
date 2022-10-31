using AutoMapper;
using GameCritic.Domain.Auth;
using GameCritic.Application.Common.Dtos.Review;
using GameCritic.Domain.Entities;
using GameCritic.Application.App.Commands.Reviews;

namespace GameCritic.Application.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewListDto>()
                .ForMember(r => r.User, c => c.MapFrom(u => u.User));

            CreateMap<CreateReviewCommand, Review>();
            CreateMap<UpdateReviewCommand, Review>();
        }
    }
}