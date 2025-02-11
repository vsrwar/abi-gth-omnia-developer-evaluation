using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

/// <summary>
/// Request model for listing sales
/// </summary>
public class ListSaleRequest
{
    /// <summary>
    /// Page number and page size
    /// </summary>
    public Paging Paging { get; set; }
}