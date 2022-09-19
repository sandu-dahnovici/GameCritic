﻿using GameCritic.Domain.Entities;
using FluentValidation;

namespace GameCritic.Domain.Validation
{
    public class PublisherValidator : AbstractValidator<Publisher>
    {
        public PublisherValidator()
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
                .InclusiveBetween(10, 200000);
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