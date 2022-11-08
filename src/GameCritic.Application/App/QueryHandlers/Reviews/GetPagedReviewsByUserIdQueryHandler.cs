using AutoMapper;
using GameCritic.Application.App.Queries.Reviews;
using GameCritic.Application.Common.Dtos.Review;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.Common.Models;
using MediatR;

namespace GameCritic.Application.App.QueryHandlers.Reviews
{
    public class GetPagedReviewsByUserIdQueryHandler : IRequestHandler<GetPagedReviewsByUserIdQuery, PaginatedResult<ReviewGameListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetPagedReviewsByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResult<ReviewGameListDto>> Handle(GetPagedReviewsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var pagedReviewsDto = await _unitOfWork.ReviewRepository.GetPagedReviewsByUserId(request.Id, request.PagedRequest);
            return pagedReviewsDto;
        }
    }
}
