using AutoMapper;
using GameCritic.Application.App.Commands.Rankings;
using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Entities;
using MediatR;

namespace GameCritic.Application.App.CommandHandlers.Publishers
{
    public class DeleteRankingCommandHandler : IRequestHandler<DeleteRankingCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRankingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteRankingCommand request, CancellationToken cancellationToken)
        {
            var ranking = await _unitOfWork.RankingRepository.GetById(request.Id);

            if (ranking == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "No ranking found");

            await _unitOfWork.RankingRepository.Delete(ranking.Id);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
