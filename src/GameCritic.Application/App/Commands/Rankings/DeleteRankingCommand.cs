using MediatR;

namespace GameCritic.Application.App.Commands.Rankings
{
    public class DeleteRankingCommand : IRequest
    {
        public int Id { get; set; }
    }
}