using GameCritic.Domain.Entities;
using FluentValidation;

namespace GameCritic.Domain.Validation
{
    public class ReviewValidator : AbstractValidator<Review>
    {
        public ReviewValidator()
        {
            RuleFor(r => r.Mark)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(1, 10);
            RuleFor(r => r.Comment)
                .MaximumLength(1000);

            RuleFor(r => r.CreationDate)
                .NotEmpty()
                .NotNull()
                .InclusiveBetween(new(2000, 1, 1), DateTime.Now);

        }
    }
}
