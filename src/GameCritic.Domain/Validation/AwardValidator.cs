using GameCritic.Domain.Entities;
using FluentValidation;

namespace GameCritic.Domain.Validation
{
    public class AwardValidator : AbstractValidator<Award>
    {
        public AwardValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(a => a.Year)
                .NotEmpty()
                .InclusiveBetween(1990, DateTime.Now.Year);
        }
    }
}
