using Ambev.DeveloperEvaluation.WebApi.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Command for retrieving a product by their ID
/// </summary>
public class ListSaleCommand : IRequest<ListSaleResult>
{
    /// <summary>
    /// Page number and page size
    /// </summary>
    public Paging Paging { get; set; }
}