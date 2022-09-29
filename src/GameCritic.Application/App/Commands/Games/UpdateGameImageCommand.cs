using MediatR;
using Microsoft.AspNetCore.Http;

namespace GameCritic.Application.App.Commands.Games
{
    public class UpdateGameImageCommand : IRequest<string>
    {
        public int Id { get; set; }

        public IFormFile Image { get; set; }

    }
}
