using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

/// <summary>
/// Handler for processing DeleteProductCommand requests
/// </summary>
public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
{
    public Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}