using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

/// <summary>
/// Validator for ListSaleRequest
/// </summary>
public class ListSaleRequestValidator : AbstractValidator<ListSaleRequest>
{
    /// <summary>
    /// Initializes validation rules for ListSaleRequest
    /// </summary>
    public ListSaleRequestValidator()
    {
        RuleFor(x => x.Paging)
            .Must((_, y) => y._page >= 1)
            .WithMessage("Page must be greater than or equal to 1.");
        RuleFor(x => x.Paging)
            .Must((_, y) => y._size >= 1)
            .WithMessage("Size must be greater than or equal to 1.");
    }
}