using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for <see cref="CreateProductRequest"/> that defines validation rules for product creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Title: Required, must have no more than 100 characters
    /// - Price: Required, must be greater than or equal to 0
    /// - Description: Required, must be at least 3 characters and no more than 500 characters
    /// - CategoryId: Required
    /// - Image: Required, must have no more than 200 characters
    /// </remarks>
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters");
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price cannot be empty")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description cannot be empty")
            .MinimumLength(3).WithMessage("Description must be at least 3 characters long")
            .MaximumLength(500).WithMessage("Description must be no more than 500 characters");
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("CategoryId cannot be empty");
        RuleFor(x => x.Image)
            .NotEmpty().WithMessage("Products must have an image url")
            .MaximumLength(200).WithMessage("Image url must be no more than 200 characters");
    }
}