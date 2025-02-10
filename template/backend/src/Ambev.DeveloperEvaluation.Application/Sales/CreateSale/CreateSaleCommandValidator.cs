using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for <see cref="CreateSaleCommand"/> that defines validation rules for sale creation.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    private const int MaximumIdenticalItems = 20;
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
        RuleFor(x => x.Products)
            .Must((s, q) => ValidateMaximumIdenticalItems(q))
            .WithMessage($"It's not possible to sell above {MaximumIdenticalItems} identical items");
        RuleFor(x => x.Branch)
            .NotEmpty().WithMessage("Branch cannot be empty")
            .MinimumLength(3).WithMessage("Branch must be at least 3 characters long")
            .MaximumLength(100).WithMessage("Branch must be no more than 100 characters");
    }

    /// <summary>
    /// Verifies if all selected products match quantity business rule
    /// </summary>
    /// <param name="saleProducts">A list of <see cref="SaleProduct"/> do be verified.</param>
    /// <returns>true if all products are valide, false otherwise</returns>
    private bool ValidateMaximumIdenticalItems(IEnumerable<SaleProduct> saleProducts)
    {
        return saleProducts.All(x => x.Quantity <= MaximumIdenticalItems);
    }
}