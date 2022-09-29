using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GameCritic.Application.App.Queries.Games;
using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.Common.Models;
using GameCritic.Application.App.Commands.Games;
using GameCritic.Application.Common.Exceptions;
using GameCritic.API.Filters;

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

        [HttpGet]
        public async Task<IList<GameListDto>> GetAll()
        {
            var games = await _mediator.Send(new GetAllGamesQuery());
            return games;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var gameDto = await _mediator.Send(new GetGameByIdQuery() { GameId = id });
            return Ok(gameDto);
        }

        [HttpPost]
        public async Task<GameDto> CreateGame(CreateGameCommand createGameDto)
        {
            var gameDto = await _mediator.Send(createGameDto);
            return gameDto;
        }

        [HttpPut]
        public async Task<Unit> UpdateGame(UpdateGameCommand updateGameDto)
        {
            var unit = await _mediator.Send(updateGameDto);
            return unit;
        }

        [HttpDelete]
        public async Task<Unit> DeleteGame(DeleteGameCommand deleteGameDto)
        {
            var unit = await _mediator.Send(deleteGameDto);
            return unit;
        }

        [HttpPatch("{id}/image")]
        public async Task<IActionResult> UpdateGameImage(int id, IFormFile image)
        {
            return Ok(await _mediator.Send(new UpdateGameImageCommand { Id = id, Image = image }));
        }

        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<GameListDto>> GetPagedGames(PagedRequest pagedRequest)
        {
            var response = await _mediator.Send(new GetGamesPagedQuery() { PagedRequest = pagedRequest });
            return response;
        }
    }
}
