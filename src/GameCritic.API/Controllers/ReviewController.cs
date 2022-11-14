using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GameCritic.Application.App.Commands.Reviews;
using GameCritic.Application.App.Queries.Reviews;
using GameCritic.Application.Common.Dtos.Review;
using GameCritic.API.Filters;
using GameCritic.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using GameCritic.Domain.Auth;

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

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ReviewUserListDto> GetReviewById(int id)
        {
            var reviewDto = await _mediator.Send(new GetReviewByIdQuery() { ReviewId = id });
            return reviewDto;
        }

        [Authorize(Roles = RoleCategory.User)]
        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand createReviewCommandDto)
        {
            return Ok(await _mediator.Send(createReviewCommandDto));
        }

        [Authorize(Roles = RoleCategory.User)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand updateReviewDto, int id)
        {
            updateReviewDto.Id = id;
            return Ok(await _mediator.Send(updateReviewDto));
        }

        [AllowAnonymous]
        [HttpGet("games/{gameId}/users/{userId}")]
        public async Task<IActionResult> GetReviewByUserAndGameId(int gameId, int userId)
        {
            return Ok(await _mediator.Send(new GetReviewIdByUserAndGameIdQuery() { GameId = gameId, UserId = userId }));
        }

        [Authorize(Roles = RoleCategory.Admin + "," + RoleCategory.User)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            return Ok(await _mediator.Send(new DeleteReviewCommand() { Id = id }));
        }

        [AllowAnonymous]
        [HttpPost("paginated-search/games/{gameId}")]
        public async Task<PaginatedResult<ReviewUserListDto>> GetPagedReviewsByGameId(int gameId, PagedRequest pagedRequest)
        {
            var response = await _mediator.Send(new GetPagedReviewsByGameIdQuery() { Id = gameId, PagedRequest = pagedRequest });
            return response;
        }

        [AllowAnonymous]
        [HttpPost("paginated-search/users/{userId}")]
        public async Task<PaginatedResult<ReviewUserListDto>> GetPagedReviewsByUserId(int userId, PagedRequest pagedRequest)
        {
            var response = await _mediator.Send(new GetPagedReviewsByGameIdQuery() { Id = userId, PagedRequest = pagedRequest });
            return response;
        }
    }
}
