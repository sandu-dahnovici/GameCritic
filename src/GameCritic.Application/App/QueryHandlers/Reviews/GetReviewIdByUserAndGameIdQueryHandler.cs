using AutoMapper;
using GameCritic.Application.App.Queries.Reviews;
using GameCritic.Application.Common.Dtos.Review;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using MediatR;

namespace GameCritic.Application.App.QueryHandlers.Reviews
{
    public class GetReviewIdByUserAndGameIdQueryHandler : IRequestHandler<GetReviewIdByUserAndGameIdQuery, ReviewDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetReviewIdByUserAndGameIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ReviewDto> Handle(GetReviewIdByUserAndGameIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.ReviewRepository.GetReviewIdByUserAndGameId(request.GameId, request.UserId);

            if (review == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "Not found review, Please write one");

            var reviewDto = _mapper.Map<ReviewDto>(review);
            return reviewDto;
        }
    }
}
