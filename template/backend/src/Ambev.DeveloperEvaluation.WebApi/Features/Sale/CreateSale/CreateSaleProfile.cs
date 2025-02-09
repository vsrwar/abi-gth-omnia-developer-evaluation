﻿using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

/// <summary>
/// Profile for mapping between Application and API CreateSale responses
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale feature
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<CreateSaleResult, CreateSaleResponse>();
    }
}