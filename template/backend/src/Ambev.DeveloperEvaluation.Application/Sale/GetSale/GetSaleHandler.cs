using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale;

/// <summary>
/// Handler for processing GetSaleCommand requests
/// </summary>
public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    public Task<GetSaleResult> Handle(GetSaleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}