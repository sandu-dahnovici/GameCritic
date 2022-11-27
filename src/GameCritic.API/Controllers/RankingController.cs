using Microsoft.AspNetCore.Mvc;
using MediatR;
using GameCritic.API.Filters;
using GameCritic.Application.App.Commands.Rankings;
using GameCritic.Application.App.Queries.Rankings;
using Microsoft.AspNetCore.Authorization;
using GameCritic.Domain.Auth;

namespace GameCritic.API.Controllers
{
    [Route("api/rankings")]
    [ApiController]
    [HttpResponseExceptionFilter]
    [Authorize(Roles = RoleCategory.Admin)]
    public class RankingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RankingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRanking(CreateRankingCommand createRankingCommandDto)
        {
            return Ok(await _mediator.Send(createRankingCommandDto));
        }

        [HttpGet("available/{awardId}")]
        public async Task<IList<int>> GetAvailableRanksByAwardId(int awardId)
        {
            return await _mediator.Send(new GetAvailableRanksByAwardIdQuery() { AwardId = awardId });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRanking(int id)
        {
            return Ok(await _mediator.Send(new DeleteRankingCommand() { Id = id }));
        }

    }
}
