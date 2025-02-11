namespace Ambev.DeveloperEvaluation.Domain.Events.Sale;

/// <summary>
/// Event handler fort sale events
/// </summary>
/// <typeparam name="TEvent">SaleEvent type</typeparam>
public interface IEventHandler<TEvent> where TEvent : SaleEvent
{
    /// <summary>
    /// Handles the SaleEvent
    /// </summary>
    /// <param name="saleEvent"></param>
    /// <returns></returns>
    Task Handle(TEvent saleEvent);
}