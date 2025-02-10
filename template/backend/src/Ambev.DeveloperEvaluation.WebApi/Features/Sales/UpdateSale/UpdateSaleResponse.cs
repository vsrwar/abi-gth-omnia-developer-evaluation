using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// API response model for UpdateSale operation
/// </summary>
public class UpdateSaleResponse
{
    /// <summary>
    /// The sale's number.
    /// </summary>
    public int Number { get; set; }
    
    /// <summary>
    /// The sale's unique identifier.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// The customer's unique identifier.
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// The sale's date of creation.
    /// </summary>
    public DateTime DateTime { get; set; }
    
    /// <summary>
    /// A list of products, containing ids and quantities
    /// </summary>
    public IEnumerable<SaleProductRequest> Products { get; set; }
        
    /// <summary>
    /// Branch where the sale was made
    /// </summary>
    public string Branch { get; set; }

    /// <summary>
    /// Discounts for sale, if match business rule
    /// </summary>
    public SaleDiscount? Discount { get; set; }
    
    /// <summary>
    /// Sales status, can be created or canceled
    /// </summary>
    public SaleStatus Status { get; set; }
}