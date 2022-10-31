using AutoMapper;
using GameCritic.Application.App.Queries.Awards;
using GameCritic.Application.Common.Dtos.Award;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using MediatR;

namespace GameCritic.Application.App.QueryHandlers.Reviews
{
    public class GetAwardByIdQueryHandler : IRequestHandler<GetAwardByIdQuery, AwardDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAwardByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<AwardDto> Handle(GetAwardByIdQuery request, CancellationToken cancellationToken)
        {
            var award = await _unitOfWork.AwardRepository.GetAward(r => r.Id == request.AwardId);

            if (award == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "No award found");

            var awardDto = _mapper.Map<AwardDto>(award);

            return awardDto;
        }
    }
}
