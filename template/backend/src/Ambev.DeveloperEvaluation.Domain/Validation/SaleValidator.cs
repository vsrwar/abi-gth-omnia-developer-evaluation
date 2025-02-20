using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    private const int MaximumIdenticalItems = 20;
    public SaleValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId cannot be empty.");
        RuleFor(x => x.Products)
            .NotEmpty().WithMessage("Products must have at least one product.");
        RuleFor(x => x.Products)
            .Must((s, q) => ValidateMaximumIdenticalItems(q))
            .WithMessage($"It's not possible to sell above {MaximumIdenticalItems} identical items.");
        RuleFor(x => x.Branch)
            .NotEmpty().WithMessage("Branch cannot be empty.")
            .MinimumLength(3).WithMessage("Branch must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Branch must be no more than 100 characters.");
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