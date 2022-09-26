using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GameCritic.Application.App.Queries.Publishers;
using GameCritic.Application.Common.Dtos.Publisher;
using GameCritic.Application.Common.Models;

namespace GameCritic.API.Controllers
{
    [Route("api/publishers")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PublisherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<PublisherDto> GetById(int id)
        {
            var publisherDto = await _mediator.Send(new GetPublisherByIdQuery() { PublisherId = id });
            return publisherDto;
        }

        //[HttpPost("paginated-search")]
        //public async Task<PaginatedResult<ListPublisherDto>> GetPagedGames(PagedRequest pagedRequest)
        //{
        //    var response = await _mediator.Send(new GetPublishersPagedQuery() { PagedRequest = pagedRequest });
        //    return response;
        //}
    }
}
