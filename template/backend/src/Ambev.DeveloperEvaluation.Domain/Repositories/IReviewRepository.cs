using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Review entity operations
/// </summary>
public interface IReviewRepository
{
    /// <summary>
    /// Creates a new review in the repository
    /// </summary>
    /// <param name="review">The review to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created review</returns>
    Task<Review> CreateAsync(Review review, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves reviews by product id paged
    /// </summary>
    /// <param name="productId">Unique identifier of product.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The review if found, null otherwise</returns>
    Task<IEnumerable<Review>> GetByProductAsync(Guid productId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a review by their unique identifier
    /// </summary>
    /// <param name="userId">Unique identifier of user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The review if found, null otherwise</returns>
    Task<IEnumerable<Review>> GetByUserAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a review
    /// </summary>
    /// <param name="review">The review to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The review if found, null otherwise</returns>
    Task<Review> UpdateAsync(Review review, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a review from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the review to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the review was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}