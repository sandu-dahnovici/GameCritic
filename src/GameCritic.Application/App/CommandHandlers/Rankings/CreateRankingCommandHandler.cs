using AutoMapper;
using GameCritic.Application.App.Commands.Rankings;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Entities;
using MediatR;


namespace GameCritic.Application.App.CommandHandlers.Rankings
{
    internal class CreateRankingCommandHandler : IRequestHandler<CreateRankingCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRankingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateRankingCommand request, CancellationToken cancellationToken)
        {
            var ranking = _mapper.Map<Ranking>(request);

            _unitOfWork.RankingRepository.Add(ranking);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
