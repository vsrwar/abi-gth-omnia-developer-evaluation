using MongoDB.Bson;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sale;

/// <summary>
/// Implementation of <see cref="SaleEvent"/> that handles SaleCancelledEvent
/// </summary>
public class SaleCancelledEvent : SaleEvent
{
    public SaleCancelledEvent(ObjectId saleId) : base(saleId)
    {
    }
}