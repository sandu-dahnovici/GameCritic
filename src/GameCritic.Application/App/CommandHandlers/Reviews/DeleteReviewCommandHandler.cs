using AutoMapper;
using GameCritic.Application.App.Commands.Reviews;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GameCritic.Application.App.CommandHandlers.Reviews
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public DeleteReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.ReviewRepository.GetById(request.Id);

            if (review == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "No review found");

            await _unitOfWork.ReviewRepository.Delete(review.Id);

            await _unitOfWork.SaveAsync();

            await UpdateScore.UpdateGameScore(_unitOfWork, review.GameId);
            await UpdateScore.UpdateUserScore(_userManager, _unitOfWork, review.UserId);

            return Unit.Value;
        }
    }
}
