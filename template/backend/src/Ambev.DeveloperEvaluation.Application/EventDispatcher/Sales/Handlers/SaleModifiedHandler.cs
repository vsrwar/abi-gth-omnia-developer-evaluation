using Ambev.DeveloperEvaluation.Domain.Events.Sale;
using Serilog;

namespace Ambev.DeveloperEvaluation.Application.EventDispatcher.Sales.Handlers;

/// <summary>
/// Implements interface <see cref="IEventHandler"/>, handles SaleModifiedEvent
/// </summary>
public class SaleModifiedHandler : IEventHandler<SaleModifiedEvent>
{
    public Task Handle(SaleModifiedEvent saleEvent)
    {
        Log.Warning($"{saleEvent.OccurredOn} - Sale with ID: {saleEvent.SaleId} modified.");
        return Task.CompletedTask;
    }
}