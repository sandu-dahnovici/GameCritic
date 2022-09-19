using GameCritic.Domain.Entities;
using FluentValidation;

namespace GameCritic.Domain.Validation
{
    public class GameAwardValidator : AbstractValidator<GameAward>
    {
        public GameAwardValidator()
        {
            RuleFor(ga => ga.Rank)
                .NotEmpty()
                .NotNull()
                .InclusiveBetween(1, 10);
        }
    }
}
