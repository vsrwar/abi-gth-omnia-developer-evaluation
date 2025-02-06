using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation.Product;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a product review in the system.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Review : BaseEntity
{
    /// <summary>
    /// Gets the customer's unique identifier of the review.
    /// Must not be null or empty
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Gets the product's unique identifier of the review.
    /// Must not be null or empty
    /// </summary>
    public Guid ProductId { get; set; }
    
    /// <summary>
    /// Gets the rate.
    /// Must not be null or empty
    /// </summary>
    public decimal Rate { get; set; }
    
    /// <summary>
    /// Gets the review's description.
    /// May contain a description of the review | Can be null
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Performs validation of the review entity using the ReviewValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">UserId length</list>
    /// <list type="bullet">ProductId length</list>
    /// <list type="bullet">Rate value</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new ReviewValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(vf => (ValidationErrorDetail)vf)
        };
    }
}