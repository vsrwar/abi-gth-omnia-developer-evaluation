using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Validator for ListSaleCommand
/// </summary>
public class ListSaleCommandValidator : AbstractValidator<ListSaleCommand>
{
    /// <summary>
    /// Initializes validation rules for ListSaleCommand
    /// </summary>
    public ListSaleCommandValidator()
    {
        RuleFor(x => x.Paging)
            .Must((_, y) => y._page >= 1)
            .WithMessage("Page must be greater than or equal to 1.");
        RuleFor(x => x.Paging)
            .Must((_, y) => y._size >= 1)
            .WithMessage("Size must be greater than or equal to 1.");
    }
}