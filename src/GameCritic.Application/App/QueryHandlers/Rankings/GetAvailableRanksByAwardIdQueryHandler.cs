using AutoMapper;
using GameCritic.Application.App.Queries.Rankings;
using GameCritic.Application.Common.Interfaces.Repositories;
using MediatR;

namespace GameCritic.Application.App.QueryHandlers.Awards
{
    public class GetAvailableRanksByAwardIdQueryHandler : IRequestHandler<GetAvailableRanksByAwardIdQuery, IList<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAvailableRanksByAwardIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<int>> Handle(GetAvailableRanksByAwardIdQuery request, CancellationToken cancellationToken)
        {
            var availableRanks = await _unitOfWork.AwardRepository.GetAvailableRanksByAwardId(request.AwardId);

            return availableRanks;
        }
    }

}
