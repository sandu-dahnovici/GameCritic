using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GameCritic.Application.App.Queries.Genres;
using GameCritic.Application.Common.Dtos.Genre;

namespace GameCritic.API.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}/games")]
        public async Task<GenreDto> GetById(int id)
        {
            var genreDto = await _mediator.Send(new GetGenreByIdQuery() { GenreId = id });
            return genreDto;
        }
    }
}
