using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GameCritic.Application.App.Commands.Reviews;
using GameCritic.Application.App.Queries.Reviews;
using GameCritic.Application.Common.Dtos.Review;
using GameCritic.API.Filters;

namespace GameCritic.API.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    [HttpResponseExceptionFilter]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ReviewListDto> GetReviewById(int id)
        {
            var reviewDto = await _mediator.Send(new GetReviewByIdQuery() { ReviewId = id });
            return reviewDto;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand createReviewCommandDto)
        {
            return Ok(await _mediator.Send(createReviewCommandDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand updateReviewDto)
        {
            return Ok(await _mediator.Send(updateReviewDto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReview(DeleteReviewCommand deleteReviewDto)
        {
            return Ok(await _mediator.Send(deleteReviewDto));
        }
    }
}
