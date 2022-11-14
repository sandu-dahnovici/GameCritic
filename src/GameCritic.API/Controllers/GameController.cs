using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using GameCritic.Application.App.Queries.Games;
using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.Common.Models;
using GameCritic.Application.App.Commands.Games;
using GameCritic.API.Filters;
using GameCritic.Domain.Auth;

namespace GameCritic.API.Controllers
{
    [Route("api/games")]
    [ApiController]
    [HttpResponseExceptionFilter]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var gameDto = await _mediator.Send(new GetGameByIdQuery() { GameId = id });
            return Ok(gameDto);
        }

        [Authorize(Roles = RoleCategory.Admin)]
        [HttpPost]
        public async Task<ActionResult<GameDto>> CreateGame(CreateGameCommand createGameDto)
        {
            var gameDto = await _mediator.Send(createGameDto);
            return CreatedAtAction(nameof(GetById), new { id = gameDto.Id }, gameDto);
        }

        [Authorize(Roles = RoleCategory.Admin)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> UpdateGame(UpdateGameCommand updateGameDto, int id)
        {
            updateGameDto.Id = id;
            var unit = await _mediator.Send(updateGameDto);
            return Ok(unit);
        }

        [Authorize(Roles = RoleCategory.Admin)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteGame(int id)
        {
            var unit = await _mediator.Send(new DeleteGameCommand { Id = id });
            return Ok(unit);
        }

        [Authorize(Roles = RoleCategory.Admin)]
        [HttpPatch("{id}/image")]
        public async Task<IActionResult> UpdateGameImage(int id, IFormFile image)
        {
            return Ok(await _mediator.Send(new UpdateGameImageCommand { Id = id, Image = image }));
        }

        [Authorize(Roles = RoleCategory.Admin)]
        [HttpDelete("{id}/image")]
        public async Task<IActionResult> DeleteGameImage(int id)
        {
            return Ok(await _mediator.Send(new DeleteGameImageCommand { Id = id }));
        }

        [AllowAnonymous]
        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<GameListDto>> GetPagedGames(PagedRequest pagedRequest)
        {
            var response = await _mediator.Send(new GetGamesPagedQuery() { PagedRequest = pagedRequest });
            return response;
        }

        [AllowAnonymous]
        [HttpGet("paginated-search")]
        public async Task<PaginatedResult<GameListDto>> GetPagedQueryGames([FromQuery] PagedRequest pagedRequest)
        {
            var response = await _mediator.Send(new GetGamesPagedQuery() { PagedRequest = pagedRequest });
            return response;
        }
    }
}
