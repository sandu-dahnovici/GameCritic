using AutoMapper;
using GameCritic.Application.App.Queries.Reviews;
using GameCritic.Application.Common.Dtos.Review;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using MediatR;

namespace GameCritic.Application.App.QueryHandlers.Reviews
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, ReviewUserListDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetReviewByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ReviewUserListDto> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.ReviewRepository.GetWithInclude(r => r.Id == request.ReviewId, r => r.User);

            if (review == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "No review found");

            var reviewDto = _mapper.Map<ReviewUserListDto>(review);

            return reviewDto;
        }
    }
}
