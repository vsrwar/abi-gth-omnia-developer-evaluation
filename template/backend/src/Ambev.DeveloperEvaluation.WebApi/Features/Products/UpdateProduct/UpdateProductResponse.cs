namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// API response model for UpdateProduct operation
/// </summary>
public class UpdateProductResponse
{
    /// <summary>
    /// The product unique identifier.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// The product's title.
    /// </summary>
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    /// The product's current price.
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// The product's description.
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// The product's category unique identifier.
    /// </summary>
    public string Category { get; set; } = string.Empty;
    
    /// <summary>
    /// The product's image.
    /// </summary>
    public string Image { get; set; } = string.Empty;
}