using AutoMapper;
using GameCritic.Application.App.Commands.Reviews;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using MediatR;

namespace GameCritic.Application.App.CommandHandlers.Reviews
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.ReviewRepository.GetById(request.Id);

            if (review == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "No review found");

            await _unitOfWork.ReviewRepository.Delete(review.Id);

            await _unitOfWork.SaveAsync();

            await UpdateGameScore.Update(_unitOfWork, review.GameId);

            return Unit.Value;
        }
    }
}
