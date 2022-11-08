using AutoMapper;
using GameCritic.Application.App.Queries.Reviews;
using GameCritic.Application.Common.Dtos.Review;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.Common.Models;
using MediatR;

namespace GameCritic.Application.App.QueryHandlers.Reviews
{
    public class GetPagedReviewsByGameIdQueryHandler : IRequestHandler<GetPagedReviewsByGameIdQuery, PaginatedResult<ReviewUserListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetPagedReviewsByGameIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResult<ReviewUserListDto>> Handle(GetPagedReviewsByGameIdQuery request, CancellationToken cancellationToken)
        {
            var pagedReviewsDto = await _unitOfWork.ReviewRepository.GetPagedReviewsByGameId(request.Id, request.PagedRequest);
            return pagedReviewsDto;
        }
    }

}
