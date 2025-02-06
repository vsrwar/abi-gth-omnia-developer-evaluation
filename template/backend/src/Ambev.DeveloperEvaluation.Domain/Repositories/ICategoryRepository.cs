using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Category entity operations
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// Creates a new category in the repository
    /// </summary>
    /// <param name="category">The category to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created category</returns>
    Task<Category> CreateAsync(Category category, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves categories paged
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The category if found, null otherwise</returns>
    Task<IEnumerable<Category>> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a category by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the category</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The category if found, null otherwise</returns>
    Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a category
    /// </summary>
    /// <param name="category">The category to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The category if found, null otherwise</returns>
    Task<Category> UpdateAsync(Category category, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a category from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the category to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the category was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}