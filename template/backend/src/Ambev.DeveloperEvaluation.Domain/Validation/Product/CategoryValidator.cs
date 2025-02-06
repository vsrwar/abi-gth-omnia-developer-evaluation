using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation.Product;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(category => category.Title)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long.");
    }
}