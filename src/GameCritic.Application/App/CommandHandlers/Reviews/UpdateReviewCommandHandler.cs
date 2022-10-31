using AutoMapper;
using GameCritic.Application.App.Commands.Reviews;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Entities;
using MediatR;

namespace GameCritic.Application.App.CommandHandlers.Reviews
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.ReviewRepository.GetById(request.Id);

            if (review == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "No review found");

            _mapper.Map(request, review);

            _unitOfWork.ReviewRepository.Update(review);

            await _unitOfWork.SaveAsync();

            await UpdateGameScore.Update(_unitOfWork, request.GameId);

            return Unit.Value;
        }
    }
}
