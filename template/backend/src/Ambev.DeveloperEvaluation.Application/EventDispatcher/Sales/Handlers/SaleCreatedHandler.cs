using Ambev.DeveloperEvaluation.Domain.Events.Sale;

namespace Ambev.DeveloperEvaluation.Application.EventDispatcher.Sales.Handlers;

/// <summary>
/// Implements interface <see cref="IEventHandler"/>, handles SaleCreatedHandler
/// </summary>
public class SaleCreatedHandler : IEventHandler<SaleCreatedEvent>
{
    public Task Handle(SaleCreatedEvent saleEvent)
    {
       Serilog.Log.Warning($"{saleEvent.OccurredOn} - New sale with ID: {saleEvent.SaleId} and total: {saleEvent.Total}");
        return Task.CompletedTask;
    }
}