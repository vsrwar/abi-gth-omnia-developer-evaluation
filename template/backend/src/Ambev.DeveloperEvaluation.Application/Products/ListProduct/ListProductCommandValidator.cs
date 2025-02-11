using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

/// <summary>
/// Validator for ListProductCommand
/// </summary>
public class ListProductCommandValidator : AbstractValidator<ListProductCommand>
{
    /// <summary>
    /// Initializes validation rules for ListProductCommand
    /// </summary>
    public ListProductCommandValidator()
    {
        RuleFor(x => x.Paging)
            .Must((_, y) => y._page >= 1)
            .WithMessage("Page must be greater than or equal to 1.");
        RuleFor(x => x.Paging)
            .Must((_, y) => y._size >= 1)
            .WithMessage("Size must be greater than or equal to 1.");
    }
}