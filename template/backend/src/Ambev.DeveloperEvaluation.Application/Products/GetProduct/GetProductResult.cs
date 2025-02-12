namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Response model for GetProduct operation
/// </summary>
public class GetProductResult
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
    /// The product's category.
    /// </summary>
    public string Category { get; set; } = string.Empty;
    
    /// <summary>
    /// The product's image.
    /// </summary>
    public string Image { get; set; } = string.Empty;
}