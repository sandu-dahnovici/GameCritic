using AutoMapper;
using GameCritic.Application.App.Commands.Users;
using GameCritic.Application.Common.Dtos.User;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.Common.Interfaces.Services;
using GameCritic.Domain.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace GameCritic.Application.App.CommandHandlers.Users
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserTokenDto>
    {
        private readonly IAuthenticationService _authService;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;


        public LoginUserCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager,
        IAuthenticationService authService, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<UserTokenDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            if (!await _authService.ValidateUser(request.Email, request.Password))
                throw new HttpResponseException(HttpStatusCode.Unauthorized, "Incorrect account email or password");

            var user = await _userManager.FindByEmailAsync(request.Email);
            var roles = await _userManager.GetRolesAsync(user);
            var userTokenDto = _mapper.Map<UserTokenDto>(user);
            userTokenDto.Token = await _authService.CreateToken();

            userTokenDto.Role = roles[0];

            return userTokenDto;
        }
    }
}
