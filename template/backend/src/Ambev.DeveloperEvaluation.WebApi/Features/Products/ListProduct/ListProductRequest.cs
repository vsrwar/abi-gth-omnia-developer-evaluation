using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProduct;

/// <summary>
/// Request model for listing products
/// </summary>
public class ListProductRequest
{
    /// <summary>
    /// Page number and page size
    /// </summary>
    public Paging Paging { get; set; }
}