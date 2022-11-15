using MediatR;

namespace GameCritic.Application.App.Commands.Reviews
{
    public class UpdateReviewCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public int Mark { get; set; }

        public string? Comment { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
