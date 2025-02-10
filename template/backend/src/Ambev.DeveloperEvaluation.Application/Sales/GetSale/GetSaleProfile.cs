using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Profile for mapping between Sales entity and GetSaleResponse
/// </summary>
public class GetSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSale operation
    /// </summary>
    public GetSaleProfile()
    {
        CreateMap<Domain.Entities.Sale, GetSaleResult>()
            .ForMember(dst => dst.Id, opt => opt.MapFrom(
                src => src._id.ToString()));
    }
}