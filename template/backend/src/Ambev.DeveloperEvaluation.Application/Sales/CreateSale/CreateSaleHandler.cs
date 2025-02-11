using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events.Sale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly ISaleEventDispatcher _saleEventDispatcher;

    /// <summary>
    /// Initializes a new instance of CreateProductHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="productRepository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="saleEventDispatcher">Event dispatcher for sale events</param>
    public CreateSaleHandler(ISaleRepository saleRepository,
        IProductRepository productRepository,
        IMapper mapper,
        ISaleEventDispatcher saleEventDispatcher)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _saleEventDispatcher = saleEventDispatcher;
        _productRepository = productRepository;
    }
    
    /// <summary>
    /// Handles the CreateSaleCommand request
    /// </summary>
    /// <param name="request">The CreateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product details</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        var productIds = request.Products.Select(p => p.ProductId).ToList();
        var products = await _productRepository.GetByIdsAsync(productIds, cancellationToken);
        
        var sale = _mapper.Map<Sale>(request);
        sale.Calculate(products);

        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

        await _saleEventDispatcher.PublishAsync(new SaleCreatedEvent(sale._id, sale.UserId, sale.TotalAmount));
        
        return _mapper.Map<CreateSaleResult>(createdSale);
    }
}