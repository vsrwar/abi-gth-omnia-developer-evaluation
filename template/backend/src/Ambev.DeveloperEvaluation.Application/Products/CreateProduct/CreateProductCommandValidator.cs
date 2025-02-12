using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for <see cref="CreateProductCommand"/> that defines validation rules for product creation.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Title: Required, must have no more than 100 characters
    /// - Price: Required, must be greater than or equal to 0
    /// - Description: Required, must be at least 3 characters and no more than 500 characters
    /// - Category: Required
    /// - Image: Required, must have no more than 200 characters
    /// </remarks>
    public CreateProductCommandValidator()
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
        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category cannot be empty");
        RuleFor(x => x.Image)
            .NotEmpty().WithMessage("Products must have an image url")
            .MaximumLength(200).WithMessage("Image url must be no more than 200 characters");
    }
}