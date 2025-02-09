using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.DeleteSale;

/// <summary>
/// Validator for CancelSaleRequest
/// </summary>
public class DeleteSaleRequestValidator : AbstractValidator<DeleteSaleRequest>
{
    /// <summary>
    /// Initializes validation rules for CancelSaleRequest
    /// </summary>
    public DeleteSaleRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}