using FluentValidation;

namespace GameCritic.Application.App.Commands.Games
{
    public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
    {
        public CreateGameCommandValidator()
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
        }
    }
}
