﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GameCritic.Application.App.Queries.Publishers;
using GameCritic.Application.App.Commands.Publishers;
using GameCritic.Application.Common.Dtos.Publisher;
using GameCritic.API.Filters;
using GameCritic.Application.Common.Models;

namespace GameCritic.API.Controllers
{
    [Route("api/publishers")]
    [ApiController]
    [HttpResponseExceptionFilter]
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

        [HttpPost]
        public async Task<PublisherDto> CreatePublisher(CreatePublisherCommand createPublisherDto)
        {
            var publisherDto = await _mediator.Send(createPublisherDto);
            return publisherDto;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublisher(UpdatePublisherCommand updatePublisherDto, int id)
        {
            updatePublisherDto.Id = id;
            return Ok(await _mediator.Send(updatePublisherDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            return Ok(await _mediator.Send(new DeletePublisherCommand() { Id = id }));
        }

        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<PublisherListDto>> GetPagedPublishers(PagedRequest pagedRequest)
        {
            var response = await _mediator.Send(new GetPublishersPagedQuery() { PagedRequest = pagedRequest });
            return response;
        }

        [HttpGet]
        public async Task<IList<PublisherListDto>> GetAllPublishers()
        {
            var response = await _mediator.Send(new GetAllPublishersQuery());
            return response;
        }
    }
}
