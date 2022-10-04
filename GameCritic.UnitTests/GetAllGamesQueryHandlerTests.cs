using AutoMapper;
using GameCritic.Application.Common.Interfaces.Repositories;
using Moq;
using GameCritic.Application.Profiles;
using GameCritic.Application.App.Queries.Games;
using GameCritic.Application.App.QueryHandler.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using GameCritic.Domain.Entities;
using System.Threading.Tasks;
using GameCritic.Application.Common.Dtos.Game;

namespace GameCritic.UnitTests
{
    public class GetAllGamesQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;

        public GetAllGamesQueryHandlerTests()
        {
            _mockRepo = new Mock<IUnitOfWork>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<GameProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetAllGamesTest()
        {
            // Arrange
            List<Game> games = new()
            {
                new Game{ Id = 1} ,new Game{ Id = 2},new Game{ Id = 3},
            };
            _mockRepo.Setup(c => c.GameRepository.GetGames()).Returns(games);

            var handler = new GetAllGamesQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetAllGamesQuery(), CancellationToken.None);


        }
    }
}
