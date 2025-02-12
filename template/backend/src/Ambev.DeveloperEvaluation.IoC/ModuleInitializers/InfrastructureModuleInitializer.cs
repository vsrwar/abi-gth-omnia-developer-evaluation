using Ambev.DeveloperEvaluation.Application.EventDispatcher.Sales;
using Ambev.DeveloperEvaluation.Application.EventDispatcher.Sales.Handlers;
using Ambev.DeveloperEvaluation.Domain.Events.Sale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Mongo;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<MongoContext>());
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<ISaleRepository, SaleRepository>();

        builder.Services.AddScoped(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
        
        builder.Services.AddScoped<ISaleEventDispatcher, SaleEventDispatcher>();
        builder.Services.AddScoped<IEventHandler<SaleCreatedEvent>, SaleCreatedHandler>();
        builder.Services.AddScoped<IEventHandler<SaleCancelledEvent>, SaleCancelledHandler>();
        builder.Services.AddScoped<IEventHandler<SaleModifiedEvent>, SaleModifiedHandler>();
        builder.Services.AddScoped<IEventHandler<ItemCancelledEvent>, ItemCancelledHandler>();
    }
}