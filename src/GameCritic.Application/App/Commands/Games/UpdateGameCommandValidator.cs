using FluentValidation;

namespace GameCritic.Application.App.Commands.Games
{
    public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>
    {
        public UpdateGameCommandValidator()
        {
            RuleFor(g => g.Title)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(g => g.ReleaseDate)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(new DateTime(1990, 1, 1), DateTime.Now.Date);
            RuleFor(g => g.Summary)
                .NotNull()
                .NotEmpty()
                .MinimumLength(50)
                .MaximumLength(2000);
            RuleFor(g => g.Price)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(10, 300);
            RuleFor(g => g.ImageName)
                .MinimumLength(3);
            RuleFor(g => g.Playtime)
                .GreaterThan(0.5);

        }
    }
}
