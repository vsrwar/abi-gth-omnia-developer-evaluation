using Ambev.DeveloperEvaluation.Domain.Events.Sale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;
using MongoDB.Bson;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Handler for processing DeleteSaleCommand requests
/// </summary>
public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResponse>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ISaleEventDispatcher _saleEventDispatcher;
    
    /// <summary>
    /// Initializes a new instance of DeleteSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="saleEventDispatcher">Event dispatcher for sale events</param>
    public DeleteSaleHandler(ISaleRepository saleRepository, ISaleEventDispatcher saleEventDispatcher)
    {
        _saleRepository = saleRepository;
        _saleEventDispatcher = saleEventDispatcher;
    }
    
    /// <summary>
    /// Handles the DeleteSaleCommand request
    /// </summary>
    /// <param name="request">The DeleteSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteSaleResponse> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _saleRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");
        
        await _saleEventDispatcher.PublishAsync(new SaleCancelledEvent(new ObjectId(request.Id)));

        return new DeleteSaleResponse { Success = true };
    }
}