using MediatR;
using AutoMapper;
using GameCritic.Application.App.Queries.Users;
using GameCritic.Application.Common.Dtos.User;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using GameCritic.Domain.Auth;

namespace GameCritic.Application.App.QueryHandlers.Users
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetUserDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserDetailsDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            var response = _mapper.Map<UserDetailsDto>(user);

            return response;
        }
    }
}
