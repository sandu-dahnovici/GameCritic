using AutoMapper;
using GameCritic.Domain.Auth;
using GameCritic.Application.Common.Dtos.User;
using GameCritic.Application.App.Commands.Users;

namespace GameCritic.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserListDto>();
            CreateMap<User, UserTokenDto>();
            CreateMap<RegisterUserCommand, User>();
            CreateMap<User, UserDetailsDto>();
        }
    }
}