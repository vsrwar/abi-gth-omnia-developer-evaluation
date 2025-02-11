using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Profile for mapping between Sale entity and ListSaleResponse
/// </summary>
public class ListSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListSale operation
    /// </summary>
    public ListSaleProfile()
    {
        CreateMap<IEnumerable<Sale>, ListSaleResult>()
            .ForMember(dest => dest.Sales, opt =>
                opt.MapFrom(src => src)
            );
    }
}