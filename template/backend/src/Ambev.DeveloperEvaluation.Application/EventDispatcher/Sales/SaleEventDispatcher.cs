using Ambev.DeveloperEvaluation.Domain.Events.Sale;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.Application.EventDispatcher.Sales;

/// <summary>
/// An EventDispatcher that handles sale events
/// </summary>
public class SaleEventDispatcher : ISaleEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public SaleEventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task PublishAsync<T>(T saleEvent) where T : SaleEvent
    {
        var handlers = _serviceProvider.GetServices<IEventHandler<T>>();
        foreach (var handler in handlers)
        {
            await handler.Handle(saleEvent);
        }
    }
}