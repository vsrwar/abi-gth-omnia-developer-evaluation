namespace Ambev.DeveloperEvaluation.Domain.Events.Sale;

/// <summary>
/// An EventDispatcher to handle events execution
/// </summary>
public interface ISaleEventDispatcher
{
    /// <summary>
    /// Publishes an event to the handlers
    /// </summary>
    /// <param name="saleEvent">SaleEvent</param>
    /// <typeparam name="T">SaleEvent type</typeparam>
    /// <returns></returns>
    Task PublishAsync<T>(T saleEvent) where T : SaleEvent;
}