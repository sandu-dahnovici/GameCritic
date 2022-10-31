using MediatR;

namespace GameCritic.Application.App.Commands.Reviews
{
    public class CreateReviewCommand : IRequest<Unit>
    {
        public int Mark { get; set; }

        public string? Comment { get; set; }

        public DateTime CreationDate { get; set; }

        public int GameId { get; set; }

        public int UserId { get; set; }
    }
}
