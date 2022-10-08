using GameCritic.Application.Common.Dtos.Publisher;
using MediatR;

namespace GameCritic.Application.App.Commands.Publishers
{
    public class DeletePublisherCommand : IRequest
    {
        public int Id { get; set; }
    }
}
