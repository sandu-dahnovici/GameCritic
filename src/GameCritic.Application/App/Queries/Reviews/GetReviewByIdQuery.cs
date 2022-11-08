using MediatR;
using GameCritic.Application.Common.Dtos.Review;

namespace GameCritic.Application.App.Queries.Reviews
{
    public class GetReviewByIdQuery : IRequest<ReviewUserListDto>
    {
        public int ReviewId { get; set; }
    }
}
