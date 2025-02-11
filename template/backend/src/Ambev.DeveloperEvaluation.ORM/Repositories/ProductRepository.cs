using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IProductRepository using Entity Framework Core
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;
    private readonly IRepositoryBase<DefaultContext, Product> _repositoryBase;

    /// <summary>
    /// Initializes a new instance of ProductRepository
    /// </summary>
    /// <param name="context">The database context</param>
    /// <param name="repositoryBase">The repository base</param>
    public ProductRepository(DefaultContext context, IRepositoryBase<DefaultContext, Product> repositoryBase)
    {
        _context = context;
        _repositoryBase = repositoryBase;
    }

    /// <summary>
    /// Creates a new product in the repository
    /// </summary>
    /// <param name="product">The product to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product</returns>
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
        => await _repositoryBase.CreateAsync(product, cancellationToken);

    /// <summary>
    /// Retrieves products paged
    /// </summary>
    /// <param name="paging">Pagination configuration</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    public Task<IEnumerable<Product>> ListAsync(Paging paging, CancellationToken cancellationToken = default)
        => _repositoryBase.ListAsync(paging, cancellationToken);

    /// <summary>
    /// Retrieves a product by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _repositoryBase.GetByIdAsync(id, cancellationToken);

    /// <summary>
    /// Retrieves a IEnumerable of products by their unique identifier
    /// </summary>
    /// <param name="productIds">List with all unique identifiers of the products</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product list if found, empty collection otherwise</returns>
    public async Task<IEnumerable<Product>> GetByIdsAsync(List<Guid> productIds, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .AsNoTracking()
            .Where(p=> productIds.Contains(p.Id))
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Updates a product
    /// </summary>
    /// <param name="product">The product to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
        => await _repositoryBase.UpdateAsync(product, cancellationToken);

    /// <summary>
    /// Deletes a product from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the product was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        => await _repositoryBase.DeleteAsync(id, cancellationToken);
}