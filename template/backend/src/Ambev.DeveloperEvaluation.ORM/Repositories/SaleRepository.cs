using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.ORM.Mongo;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleRepository using Entity Framework Core and MongoDb
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly MongoContext _context;
    private readonly IRepositoryBase<MongoContext, Sale> _repositoryBase;

    /// <summary>
    /// Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="context">The database context</param>
    /// <param name="repositoryBase">The repository base</param>
    public SaleRepository(IRepositoryBase<MongoContext, Sale> repositoryBase, MongoContext context)
    {
        _repositoryBase = repositoryBase;
        _context = context;
    }

    /// <summary>
    /// Creates a new sale in the repository
    /// </summary>
    /// <param name="sale">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        var number = await _context.Sales.CountAsync(cancellationToken: cancellationToken);
        sale.UpdateNumber(++number);;
        return await _repositoryBase.CreateAsync(sale, cancellationToken);
    } 

    /// <summary>
    /// Retrieves sales paged
    /// </summary>
    /// <param name="paging">Pagination configuration</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public Task<IEnumerable<Sale>> ListAsync(Paging paging, CancellationToken cancellationToken = default)
        => _repositoryBase.ListAsync(paging, cancellationToken);

    /// <summary>
    /// Retrieves a sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<Sale?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        => await _repositoryBase.GetByIdAsync(new ObjectId(id), cancellationToken);

    /// <summary>
    /// Updates a sale
    /// </summary>
    /// <param name="sale">The sale to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
        => await _repositoryBase.UpdateAsync(sale, cancellationToken);

    /// <summary>
    /// Deletes a sale from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
        => await _repositoryBase.DeleteAsync(new ObjectId(id), cancellationToken);
}