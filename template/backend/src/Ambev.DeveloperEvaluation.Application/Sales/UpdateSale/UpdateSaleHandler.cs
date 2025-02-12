using Ambev.DeveloperEvaluation.Domain.Events.Sale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using SaleModifiedEvent = Ambev.DeveloperEvaluation.Domain.Events.Sale.SaleModifiedEvent;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Handler for processing UpdateSaleCommand requests
/// </summary>
public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly ISaleEventDispatcher _saleEventDispatcher;

    /// <summary>
    /// Initializes a new instance of UpdateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="productRepository">the product repository</param>
    /// <param name="saleEventDispatcher">Event dispatcher for sale events</param>
    public UpdateSaleHandler(ISaleRepository saleRepository,
        IMapper mapper,
        IProductRepository productRepository,
        ISaleEventDispatcher saleEventDispatcher)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _productRepository = productRepository;
        _saleEventDispatcher = saleEventDispatcher;
    }

    /// <summary>
    /// Handles the UpdateSaleCommand request
    /// </summary>
    /// <param name="request">The UpdateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var saleOld = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
        if (saleOld == null)
            throw new KeyNotFoundException($"Sales with ID {request.Id} not found");

        var productIds = request.Products.Select(p => p.ProductId).ToList();
        var products = await _productRepository.GetByIdsAsync(productIds, cancellationToken);
        
        saleOld.Update(request.Products, request.Branch);
        saleOld.Calculate(products);

        await _saleRepository.UpdateAsync(saleOld, cancellationToken);
        
        await _saleEventDispatcher.PublishAsync(new SaleModifiedEvent(saleOld._id));
        
        var result = _mapper.Map<UpdateSaleResult>(saleOld);
        return result;
    }
}