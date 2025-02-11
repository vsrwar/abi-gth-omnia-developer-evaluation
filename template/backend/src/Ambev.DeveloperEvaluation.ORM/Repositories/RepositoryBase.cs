using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class RepositoryBase<TContext, T> : IRepositoryBase<TContext, T>
    where T : class
    where TContext : DbContext
{
    private readonly DbContext _context;
    private readonly DbSet<T> _entities;

    public RepositoryBase(TContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    /// <summary>
    /// Creates a new entity in the repository
    /// </summary>
    /// <param name="entity">The entity to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created entity</returns>
    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _entities.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    /// <summary>
    /// Retrieves entitys paged
    /// </summary>
    /// <param name="paging">Pagination configuration</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The entity if found, null otherwise</returns>
    public async Task<IEnumerable<T>> ListAsync(Paging paging, CancellationToken cancellationToken = default)
    {
        return await _entities
            .AsNoTracking()
            .Skip(paging._size * (paging._page - 1))
            .Take(paging._size)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves a entity by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the entity</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The entity if found, null otherwise</returns>
    public async Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default)
    {
        return await _entities.FindAsync([id], cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Updates a entity
    /// </summary>
    /// <param name="entity">The entity to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The entity if found, null otherwise</returns>
    public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _entities.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        
        return entity;
    }

    /// <summary>
    /// Deletes a entity from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the entity was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(object id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity == null)
            return false;
        
        _entities.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}