﻿using MediatR;
using AutoMapper;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Application.Common.Dtos.Publisher;
using GameCritic.Application.App.Queries.Publishers;
using GameCritic.Application.Common.Exceptions;

namespace GameCritic.Application.App.QueryHandlers.Publishers
{
    public class GetPublisherByIdQueryHandler : IRequestHandler<GetPublisherByIdQuery, PublisherDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetPublisherByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PublisherDto> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken)
        {
            var publisher = await _unitOfWork.PublisherRepository.GetWithInclude(p => request.PublisherId == p.Id, p => p.Games);

            if (publisher == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "No publisher found");

            var publisherDto = _mapper.Map<PublisherDto>(publisher);
            return publisherDto;
        }
    }
}
