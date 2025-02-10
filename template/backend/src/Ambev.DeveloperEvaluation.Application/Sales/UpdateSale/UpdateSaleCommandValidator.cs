using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Validator for <see cref="UpdateSaleRequest"/> that defines validation rules for sale creation.
/// </summary>
public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the UpdateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Products: Required, must have at least one
    /// - Branch: Required, must have at least 3 characters and no more than 100 characters
    /// </remarks>
    public UpdateSaleCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty");
        RuleFor(x => x.Products)
            .NotEmpty().WithMessage("Products must have at least one product");
        RuleFor(x => x.Branch)
            .NotEmpty().WithMessage("Branch cannot be empty")
            .MinimumLength(3).WithMessage("Branch must be at least 3 characters long")
            .MaximumLength(100).WithMessage("Branch must be no more than 100 characters");
    }
}
