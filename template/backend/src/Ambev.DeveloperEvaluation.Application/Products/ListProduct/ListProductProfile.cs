using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

/// <summary>
/// Profile for mapping between Product entity and ListProductResponse
/// </summary>
public class ListProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProduct operation
    /// </summary>
    public ListProductProfile()
    {
        CreateMap<IEnumerable<Product>, ListProductResult>()
            .ForMember(dest => dest.Products, opt =>
                opt.MapFrom(src => src)
            );
    }
}