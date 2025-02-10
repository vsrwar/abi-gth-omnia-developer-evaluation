﻿using Ambev.DeveloperEvaluation.Application.Sale.DeleteSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.DeleteSale;

/// <summary>
/// Profile for mapping DeleteSale feature requests to commands
/// </summary>
public class DeleteSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteSale feature
    /// </summary>
    public DeleteSaleProfile()
    {
        CreateMap<Guid, DeleteSaleCommand>()
            .ConstructUsing(id => new DeleteSaleCommand(id));
    }
}