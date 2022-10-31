using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;

namespace GameCritic.Application.App.CommandHandlers.Reviews
{
    public static class UpdateGameScore
    {
        public static async Task Update(IUnitOfWork unitOfWork, int id)
        {
            var game = await unitOfWork.GameRepository.GetGameById(id);

            if (game == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "This game cannot be found");

            var reviews = await unitOfWork.ReviewRepository.GetReviewsByGameId(id);

            double score = 0;

            if (reviews.Count != 0)
                score = reviews.Average(r => r.Mark);

            game.Score = Math.Round(score, 1);
            game.Price = Math.Round(game.Price, 1);

            unitOfWork.GameRepository.Update(game);

            await unitOfWork.SaveAsync();
        }
    }
}
