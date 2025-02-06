using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation.Product;

public class ReviewValidator : AbstractValidator<Review>
{
    public ReviewValidator()
    {
        RuleFor(r => r.CustomerId)
            .NotEmpty().WithMessage("Customer ID is required.");

        RuleFor(r => r.ProductId)
            .NotEmpty().WithMessage("Product ID is required.");
        
        RuleFor(r => r.Rate)
            .GreaterThan(0).WithMessage("Rate must be at least 0.");
        
        RuleFor(r => r.Description)
            .MaximumLength(500).WithMessage("Description cannot be longer than 500 characters.");
    }
}