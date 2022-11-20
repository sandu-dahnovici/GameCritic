using Microsoft.AspNetCore.Mvc;
using MediatR;
using GameCritic.API.Filters;
using GameCritic.Application.App.Commands.Rankings;
using Microsoft.AspNetCore.Authorization;
using GameCritic.Domain.Auth;

namespace GameCritic.API.Controllers
{
    [Route("api/rankings")]
    [ApiController]
    [HttpResponseExceptionFilter]
    public class RankingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RankingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = RoleCategory.Admin)]
        [HttpPost]
        public async Task<IActionResult> CreateRanking(CreateRankingCommand createRankingCommandDto)
        {
            return Ok(await _mediator.Send(createRankingCommandDto));
        }


    }
}
