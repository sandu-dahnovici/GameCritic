using GameCritic.Application.Common.Dtos.User;
using MediatR;

namespace GameCritic.Application.App.Commands.Users
{
    public class LoginUserCommand : IRequest<UserTokenDto>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
