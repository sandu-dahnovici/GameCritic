using Microsoft.AspNetCore.Mvc;
using MediatR;
using GameCritic.API.Filters;
using GameCritic.Application.Common.Dtos.Award;
using GameCritic.Application.App.Queries.Awards;
using Microsoft.AspNetCore.Authorization;
using GameCritic.Domain.Auth;

namespace GameCritic.API.Controllers
{
    [Route("api/awards")]
    [ApiController]
    [HttpResponseExceptionFilter]
    public class AwardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AwardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<AwardDto> GetAwardById(int id)
        {
            var awardDto = await _mediator.Send(new GetAwardByIdQuery() { AwardId = id });
            return awardDto;
        }

        [Authorize(Roles = RoleCategory.Admin)]
        [HttpGet("available/{gameId}")]
        public async Task<IList<AwardListDto>> GetAvailableAwardsByGameId(int gameId)
        {
            return await _mediator.Send(new GetAvailableAwardsByGameIdQuery() { GameId = gameId });
        }
    }
}
