using AutoMapper;
using GameCritic.Application.App.Commands.Reviews;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Auth;
using GameCritic.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GameCritic.Application.App.CommandHandlers.Reviews
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CreateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = _mapper.Map<Review>(request);

            _unitOfWork.ReviewRepository.Add(review);

            await _unitOfWork.SaveAsync();

            await UpdateScore.UpdateGameScore(_unitOfWork, request.GameId);
            await UpdateScore.UpdateUserScore(_userManager, _unitOfWork, request.UserId);

            return Unit.Value;
        }
    }
}
