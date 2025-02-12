using MongoDB.Bson;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sale;

/// <summary>
/// Implementation of <see cref="SaleEvent"/> that handles SaleCreatedEvent
/// </summary>
public class SaleCreatedEvent : SaleEvent
{
    public Guid UserId { get; private set; }
    public decimal Total { get; private set; }
    
    public SaleCreatedEvent(ObjectId saleId, Guid userId, decimal total) : base(saleId)
    {
        UserId = userId;
        Total = total;
    }
}