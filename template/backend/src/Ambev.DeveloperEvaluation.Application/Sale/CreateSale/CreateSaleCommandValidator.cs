using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;

/// <summary>
/// Validator for <see cref="CreateSaleCommand"/> that defines validation rules for sale creation.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserId: Must be valid format and not empty
    /// - Products: Required, must have at least one
    /// - Branch: Required, must have at least 3 characters and no more than 100 characters
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId cannot be empty");
        RuleFor(x => x.Products)
            .NotEmpty().WithMessage("Products must have at least one product");
        RuleFor(x => x.Branch)
            .NotEmpty().WithMessage("Branch cannot be empty")
            .MinimumLength(3).WithMessage("Branch must be at least 3 characters long")
            .MaximumLength(100).WithMessage("Branch must be no more than 100 characters");
    }
}