using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation.Product;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a product in the system with its characteristics.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Product : BaseEntity
{
    /// <summary>
    /// Gets the product's title.
    /// Must not be null or empty
    /// </summary>
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets the product's current price.
    /// Must be a valid price, greater than or equal to zero.
    /// </summary>
    public decimal Price { get; private set; }
    
    /// <summary>
    /// Gets the product's description.
    /// Must be a clear description of the product, it may contain the color, size, or any other specific characteristic.
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets the product's category.
    /// Category of product.
    /// </summary>
    public string Category { get; set; }
    
    /// <summary>
    /// Gets the product's image.
    /// A image location (uri).
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's rating.
    /// Returns current rate and count.
    /// </summary>
    public Rating? Rating { get; set; }
    
    /// <summary>
    /// Gets the product's reviews.
    /// Returns a collection with product reviews.
    /// </summary>
    public ICollection<Review> Reviews { get; set; }

    /// <summary>
    /// Performs validation of the product entity using the ProductValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Title format and length</list>
    /// <list type="bullet">Price value</list>
    /// <list type="bullet">Description format</list>
    /// <list type="bullet">Image format</list>
    /// <list type="bullet">Category</list>
    /// <list type="bullet">Rating</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new ProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(vf => (ValidationErrorDetail)vf)
        };
    }
    
    /// <summary>
    /// Changes product's price.
    /// Must be a valid price, greater than or equal to zero.
    /// </summary>
    /// <param name="newPrice">The new price of the product.</param>
    /// <exception cref="ArgumentException">Price can not be less than zero.</exception>
    public void UpdatePrice(decimal newPrice)
    {
        if(newPrice < 0)
            throw new ArgumentException("Price cannot be negative");
        Price = newPrice;
    }
}