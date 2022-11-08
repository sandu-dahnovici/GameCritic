using AutoMapper;
using GameCritic.Application.App.Commands.Users;
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
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserListDto>
    {
        private readonly IAuthenticationService _authService;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;


        public RegisterUserCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager,
        IAuthenticationService authService, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<UserListDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            int isValid = await _authService.ValidateUsernameAndEmail(request.Username, request.Email);

            if (isValid > 0)
            {
                if (isValid == 1)
                    throw new HttpResponseException(HttpStatusCode.Conflict, "This username is already taken");
                else
                    throw new HttpResponseException(HttpStatusCode.Conflict, "This email is already taken");
            }

            var user = _mapper.Map<User>(request);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new HttpResponseException(HttpStatusCode.BadRequest,
                    result.Errors.Select(e => e.Description).First());

            if (await _roleManager.RoleExistsAsync(RoleCategory.User)) await _userManager.AddToRoleAsync(user, RoleCategory.User);

            user = await _userManager.FindByEmailAsync(request.Email);

            return _mapper.Map<UserListDto>(user);
        }
    }
}
