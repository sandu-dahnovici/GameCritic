using MediatR;

namespace GameCritic.Application.App.Commands.Reviews
{
    public class DeleteReviewCommand : IRequest
    {
        public int Id { get; set; }
    }
}
