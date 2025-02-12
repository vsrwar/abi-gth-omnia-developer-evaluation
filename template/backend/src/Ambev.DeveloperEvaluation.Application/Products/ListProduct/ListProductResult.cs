using Ambev.DeveloperEvaluation.Application.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

/// <summary>
/// Response model for GetProduct operation
/// </summary>
public class ListProductResult
{
    /// <summary>
    /// The product list.
    /// </summary>
    public IEnumerable<GetProductResult> Products { get; set; }
}