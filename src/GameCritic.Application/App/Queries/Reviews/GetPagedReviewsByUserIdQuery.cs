﻿using GameCritic.Application.Common.Dtos.Review;
using GameCritic.Application.Common.Models;
using MediatR;

namespace GameCritic.Application.App.Queries.Reviews
{
    public class GetPagedReviewsByUserIdQuery : IRequest<PaginatedResult<ReviewGameListDto>>
    {
        public int Id { get; set; }
        public PagedRequest PagedRequest { get; set; }
    }
}
