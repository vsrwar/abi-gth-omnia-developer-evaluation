using Ambev.DeveloperEvaluation.Domain.Events.Sale;

namespace Ambev.DeveloperEvaluation.Application.EventDispatcher.Sales.Handlers;

/// <summary>
/// Implements interface <see cref="IEventHandler"/>, handles SaleCancelledEvent
/// </summary>
public class SaleCancelledHandler : IEventHandler<SaleCancelledEvent>
{
    public Task Handle(SaleCancelledEvent saleEvent)
    {
        Serilog.Log.Warning($"{saleEvent.OccurredOn} - Sale cancelled: {saleEvent.SaleId}");
        return Task.CompletedTask;
    }
}