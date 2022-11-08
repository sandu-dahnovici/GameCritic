using GameCritic.Application.Common.Dtos.User;
using MediatR;

namespace GameCritic.Application.App.Commands.Users
{
    public class RegisterUserCommand : IRequest<UserListDto>
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
