using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IRepositoryBase<TContext, T>
    where T : class
    where TContext : DbContext
{
    /// <summary>
    /// Creates a new entity in the repository
    /// </summary>
    /// <param name="entity">The entity to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created entity</returns>
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves entitys paged
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The entity if found, null otherwise</returns>
    Task<IEnumerable<T>> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a entity by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the entity</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The entity if found, null otherwise</returns>
    Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates a entity
    /// </summary>
    /// <param name="entity">The entity to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The entity if found, null otherwise</returns>
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a entity from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the entity was deleted, false if not found</returns>
    Task<bool> DeleteAsync(object id, CancellationToken cancellationToken = default);
}