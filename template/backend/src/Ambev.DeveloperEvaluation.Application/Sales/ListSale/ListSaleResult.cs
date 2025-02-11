using Ambev.DeveloperEvaluation.Application.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class ListSaleResult
{
    /// <summary>
    /// The product list.
    /// </summary>
    public IEnumerable<GetSaleResult> Sales { get; set; }
}