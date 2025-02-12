using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProduct;

/// <summary>
/// Validator for ListProductRequest
/// </summary>
public class ListProductRequestValidator : AbstractValidator<ListProductRequest>
{
    /// <summary>
    /// Initializes validation rules for ListProductRequest
    /// </summary>
    public ListProductRequestValidator()
    {
        RuleFor(x => x.Paging)
            .Must((_, y) => y._page >= 1)
            .WithMessage("Page must be greater than or equal to 1.");
        RuleFor(x => x.Paging)
            .Must((_, y) => y._size >= 1)
            .WithMessage("Size must be greater than or equal to 1.");
    }
}