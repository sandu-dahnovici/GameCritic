using MediatR;

namespace GameCritic.Application.App.Queries.Reviews
{
    public class GetReviewIdByUserAndGameIdQuery : IRequest<int>
    {
        public int UserId { get; set; }

        public int GameId { get; set; }
    }
}
