namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;


/// <summary>
/// Represents a request to update an existing product in the system.
/// </summary>
public class UpdateProductRequest
{
    /// <summary>
    /// Gets or sets the product's title.
    /// Must not be null or empty
    /// </summary>
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the product's current price.
    /// Must be a valid price, greater than or equal to zero.
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Gets or sets the product's description.
    /// Must be a clear description of the product, it may contain the color, size, or any other specific characteristic.
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the product's category unique identifier.
    /// Category id of product.
    /// </summary>
    public Guid CategoryId { get; set; }
    
    /// <summary>
    /// Gets or sets the product's image.
    /// A image location (uri).
    /// </summary>
    public string Image { get; set; } = string.Empty;
}