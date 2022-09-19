using GameCritic.Domain.Entities;
using FluentValidation;

namespace GameCritic.Domain.Validation
{
    public class GenreValidator : AbstractValidator<Genre>
    {
        public GenreValidator()
        {
            RuleFor(g => g.Name)
                .NotEmpty()
                .MaximumLength(30);
            RuleFor(g => g.Description)
                .NotEmpty()
                .MaximumLength(500);
        }
    }
}
