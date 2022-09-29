using AutoMapper;
using GameCritic.Domain.Auth;
using GameCritic.Application.Common.Dtos.User;

namespace GameCritic.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserListDto>();
        }
    }
}