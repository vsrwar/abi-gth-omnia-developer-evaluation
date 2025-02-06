using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation.Product;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a product category in the system.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Category : BaseEntity
{
    /// <summary>
    /// Gets the category's title.
    /// Must not be null or empty
    /// </summary>
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets a collection with all products within the category.
    /// </summary>
    public ICollection<Product> Products { get; set; }
    
    /// <summary>
    /// Performs validation of the category entity using the CategoryValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Title format and length</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new CategoryValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(vf => (ValidationErrorDetail)vf)
        };
    }
}