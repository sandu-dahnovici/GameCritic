using GameCritic.Application.Common.Exceptions;
using GameCritic.Application.Common.Interfaces.Repositories;
using GameCritic.Domain.Auth;
using Microsoft.AspNetCore.Identity;

namespace GameCritic.Application.App.CommandHandlers.Reviews
{
    public static class UpdateScore
    {
        public static async Task UpdateGameScore(IUnitOfWork unitOfWork, int id)
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

        public static async Task UpdateUserScore(UserManager<User> userManager, IUnitOfWork unitOfWork, int id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());

            if (user == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "This user cannot be found");

            var reviews = await unitOfWork.ReviewRepository.GetReviewsByUserId(id);

            double score = 0;

            if (reviews.Count != 0)
                score = reviews.Average(r => r.Mark);

            user.Score = Math.Round(score, 1);
            user.ReviewCount = reviews.Count;

            await userManager.UpdateAsync(user);

            await unitOfWork.SaveAsync();
        }
    }
}
