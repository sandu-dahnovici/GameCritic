using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GameCritic.Application.App.Queries.Genres;
using GameCritic.Application.Common.Dtos.Genre;
using GameCritic.API.Filters;
using Microsoft.AspNetCore.Authorization;

namespace GameCritic.API.Controllers
{
    [Route("api/genres")]
    [ApiController]
    [HttpResponseExceptionFilter]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("{id}/games")]
        public async Task<GenreDto> GetById(int id)
        {
            var genreDto = await _mediator.Send(new GetGenreByIdQuery() { GenreId = id });
            return genreDto;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IList<GenreListDto>> GetAllGenres()
        {
            var response = await _mediator.Send(new GetAllGenresQuery());
            return response;
        }
    }
}
