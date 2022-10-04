using FluentValidation;
using GameCritic.Application.App.Commands.Publishers;

namespace GameCritic.Application.App.Validators
{
    public class CreatePublisherCommandValidator : AbstractValidator<CreatePublisherCommand>
    {
        public CreatePublisherCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(p => p.FoundationYear)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(1970, DateTime.Now.Year);
            RuleFor(p => p.NumberOfEmployees)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(10, 2000000);
            RuleFor(p => p.WebsiteURL)
                .Custom((uriName, context) =>
                {
                    Uri uriResult;
                    bool result = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult)
                        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                    if (!result)
                        context.AddFailure("URL is not valid");
                });
            RuleFor(p => p.Country)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
