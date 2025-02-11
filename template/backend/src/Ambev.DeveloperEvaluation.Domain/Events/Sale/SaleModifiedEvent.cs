using MongoDB.Bson;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sale;

/// <summary>
/// Implementation of <see cref="SaleEvent"/> that handles SaleModifiedEvent
/// </summary>
public class SaleModifiedEvent : SaleEvent
{
    public SaleModifiedEvent(ObjectId saleId) : base(saleId)
    {
    }
}