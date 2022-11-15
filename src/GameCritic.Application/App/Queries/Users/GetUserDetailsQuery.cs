using GameCritic.Application.Common.Dtos.User;
using MediatR;

namespace GameCritic.Application.App.Queries.Users
{
    public class GetUserDetailsQuery : IRequest<UserDetailsDto>
    {
        public int UserId { get; set; }
    }
    
}
