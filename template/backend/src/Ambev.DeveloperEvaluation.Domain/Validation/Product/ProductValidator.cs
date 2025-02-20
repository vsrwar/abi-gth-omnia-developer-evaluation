using System.Text.RegularExpressions;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation.Product;

public class ProductValidator : AbstractValidator<Entities.Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Title)
            .NotEmpty().WithMessage("The title cannot be empty.")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters.");

        RuleFor(product => product.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative");
        
        RuleFor(product => product.Description)
            .NotEmpty().WithMessage("The description cannot be empty.")
            .MinimumLength(3).WithMessage("Description must be at least 3 characters long.")
            .MaximumLength(500).WithMessage("Description cannot be longer than 500 characters.");

        RuleFor(product => product.Image)
            .NotEmpty()
            .WithMessage("The image location cannot be empty.")
            .Must(BeValidUrl)
            .WithMessage("The provided url address is not valid.")
            .MaximumLength(200).WithMessage("Image cannot be longer than 200 characters.");

        RuleFor(user => user.Category)
            .NotEmpty().WithMessage("The category cannot be empty.");
    }

    private static bool BeValidUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return false;

        // More strict email validation
        var regex = new Regex(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)");
        return regex.IsMatch(url);
    }
}