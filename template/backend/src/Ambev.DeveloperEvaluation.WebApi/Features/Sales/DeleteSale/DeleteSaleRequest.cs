namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

/// <summary>
/// Request model for deleting a sale
/// </summary>
public class DeleteSaleRequest
{
    /// <summary>
    /// The unique identifier of the sale to delete
    /// </summary>
    public string Id { get; set; }
}