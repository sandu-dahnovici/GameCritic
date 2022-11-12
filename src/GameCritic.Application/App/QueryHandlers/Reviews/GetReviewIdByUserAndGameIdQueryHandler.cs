using AutoMapper;
using GameCritic.Application.App.Queries.Reviews;
using GameCritic.Application.Common.Interfaces.Repositories;
using MediatR;

namespace GameCritic.Application.App.QueryHandlers.Reviews
{
    public class GetReviewIdByUserAndGameIdQueryHandler : IRequestHandler<GetReviewIdByUserAndGameIdQuery, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetReviewIdByUserAndGameIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(GetReviewIdByUserAndGameIdQuery request, CancellationToken cancellationToken)
        {
            var id = await _unitOfWork.ReviewRepository.GetReviewIdByUserAndGameId(request.GameId, request.UserId);

            return id;
        }
    }
}
