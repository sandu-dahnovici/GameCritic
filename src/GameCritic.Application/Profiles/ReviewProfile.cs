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
            CreateMap<Review, ReviewUserListDto>()
                .ForMember(r => r.User, c => c.MapFrom(u => u.User));

            CreateMap<Review, ReviewGameListDto>()
                .ForMember(r => r.Game, c => c.MapFrom(u => u.Game));

            CreateMap<CreateReviewCommand, Review>();
            CreateMap<UpdateReviewCommand, Review>();
        }
    }
}