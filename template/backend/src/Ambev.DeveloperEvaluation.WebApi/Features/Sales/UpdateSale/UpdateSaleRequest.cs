using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Represents a request to update an existing sale in the system.
/// </summary>
public class UpdateSaleRequest
{
    /// <summary>
    /// The sale's unique identifier.
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// Gets or sets a list of products, containing ids and quantities
    /// </summary>
    public IEnumerable<SaleProductRequest> Products { get; set; }

    /// <summary>
    /// Gets or sets branch where the sale was made
    /// </summary>
    public string Branch { get; set; } = string.Empty;
}