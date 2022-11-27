using GameCritic.Application.Common.Dtos.Review;
using MediatR;

namespace GameCritic.Application.App.Queries.Reviews
{
    public class GetReviewIdByUserAndGameIdQuery : IRequest<ReviewDto>
    {
        public int UserId { get; set; }

        public int GameId { get; set; }
    }
}
