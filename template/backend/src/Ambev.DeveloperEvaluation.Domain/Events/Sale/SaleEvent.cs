using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sale;

/// <summary>
/// Represents an abstract sale event on the system
/// </summary>
public abstract class SaleEvent
{
    [BsonId]
    public ObjectId SaleId { get; }
    
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    protected SaleEvent(ObjectId saleId)
    {
        SaleId = saleId;
    }
}