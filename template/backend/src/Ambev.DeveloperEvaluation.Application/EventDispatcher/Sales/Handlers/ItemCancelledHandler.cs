using Ambev.DeveloperEvaluation.Domain.Events.Sale;
using Serilog;

namespace Ambev.DeveloperEvaluation.Application.EventDispatcher.Sales.Handlers;

/// <summary>
/// Implements interface <see cref="IEventHandler"/>, handles ItemCancelledEvent
/// </summary>
public class ItemCancelledHandler : IEventHandler<ItemCancelledEvent>
{
    public Task Handle(ItemCancelledEvent saleEvent)
    {
        Log.Warning($"{saleEvent.OccurredOn} - Sale cancelled: {saleEvent.SaleId}");
        return Task.CompletedTask;
    }
}