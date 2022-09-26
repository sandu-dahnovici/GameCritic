using MediatR;

namespace GameCritic.Application.App.Commands.Games
{
    public class DeleteGameCommand : IRequest
    {
        public int Id { get; set; }
    }
}