using AutoMapper;
using GameCritic.Application.App.Queries.Awards;
using GameCritic.Application.Common.Dtos.Award;
using GameCritic.Application.Common.Interfaces.Repositories;
using MediatR;

namespace GameCritic.Application.App.QueryHandlers.Awards
{
    public class GetAvailableAwardsByGameIdQueryHandler : IRequestHandler<GetAvailableAwardsByGameIdQuery, IList<AwardListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAvailableAwardsByGameIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<AwardListDto>> Handle(GetAvailableAwardsByGameIdQuery request, CancellationToken cancellationToken)
        {
            var awards = await _unitOfWork.AwardRepository.GetAvailableAwardsByGameId(request.GameId);

            List<AwardListDto> awardListDtos = new();
            foreach (var award in awards)
            {
                awardListDtos.Add(_mapper.Map<AwardListDto>(award));
            }

            return awardListDtos;
        }
    }

}
