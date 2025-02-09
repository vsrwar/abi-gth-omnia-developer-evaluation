using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

/// <summary>
/// Validator for <see cref="CreateSaleRequest"/> that defines validation rules for sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserId: Must be valid format and not empty
    /// - Products: Required, must have at least one
    /// </remarks>
    public CreateSaleRequestValidator()
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