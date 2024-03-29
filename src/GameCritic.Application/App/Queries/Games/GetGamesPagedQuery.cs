﻿using MediatR;
using GameCritic.Application.Common.Dtos.Game;
using GameCritic.Application.Common.Models;

namespace GameCritic.Application.App.Queries.Games
{
    public class GetGamesPagedQuery : IRequest<PaginatedResult<GameListDto>>
    {
        public PagedRequest PagedRequest { get; set; }
    }
}
