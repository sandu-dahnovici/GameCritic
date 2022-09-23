using GameCritic.Domain.Entities;
using FluentValidation;

namespace GameCritic.Domain.Validation
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(g => g.Title)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(g => g.ReleaseDate)
                .NotEmpty()
                .InclusiveBetween(new DateTime(1990, 1, 1), DateTime.Now.Date);
            RuleFor(g => g.Summary)
                .NotEmpty()
                .MinimumLength(50)
                .MaximumLength(2000);
            RuleFor(g => g.Price)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(10, 300);
            RuleFor(g => g.Score)
                .InclusiveBetween(1, 10);
        }
    }
}
