using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Profile for mapping between Sales entity and CreateSaleResponse
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale operation
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Domain.Entities.Sale>();
        CreateMap<Domain.Entities.Sale, CreateSaleResult>()
            .ForMember(dst => dst.Id, opt => opt.MapFrom(
            src => src._id.ToString()));;
    }
}