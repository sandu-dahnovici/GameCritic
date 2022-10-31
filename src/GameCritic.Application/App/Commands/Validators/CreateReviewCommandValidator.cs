using FluentValidation;
using GameCritic.Application.App.Commands.Reviews;

namespace GameCritic.Application.App.Commands.Validators
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidator()
        {
            RuleFor(r => r.Mark)
                .NotEmpty()
                .NotNull()
                .InclusiveBetween(1, 10);
            RuleFor(r => r.Comment)
                .MaximumLength(1000);
            RuleFor(r => r.CreationDate)
                .InclusiveBetween(new DateTime(1999, 1, 1), DateTime.Now);
        }
    }
}

