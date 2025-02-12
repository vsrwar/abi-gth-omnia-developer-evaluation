using MongoDB.Bson;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sale;

/// <summary>
/// Implementation of <see cref="SaleEvent"/> that handles ItemCancelledEvent
/// </summary>
public class ItemCancelledEvent : SaleEvent
{
    public Guid ProductId { get; set; }
    
    public ItemCancelledEvent(ObjectId saleId, Guid productId) : base(saleId)
    {
        ProductId = productId;
    }
}