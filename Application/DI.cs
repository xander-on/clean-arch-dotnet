

using Application.Products.Commands.CreateProduct;
using Application.UseCases.Products.Commands.CreateProduct;
using Application.UseCases.Products.Commands.StockAdjustment;
using Application.UseCases.Products.Commands.UpdateProduct;
using Application.UseCases.Products.Queries.GetProductById;
using Application.Utilities.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DI
{
    public static IServiceCollection AddApplication( this IServiceCollection services)
    {
        services.AddTransient<IMediator, SimpleMediator>();
        services.AddScoped<IRequestHandler<CreateProductCommand, Guid>, CreateProductUseCase>();
        services.AddScoped<IRequestHandler<UpdateProductCommand>, UpdateProductHandle>();
        services.AddScoped<IRequestHandler<StockAdjustmentCommand>, StockAdjustmentHandle>();
        services.AddScoped<IRequestHandler<GetProductByIdQuery, ProductDetailDto>, GetProductByIdHandle>();
        
        return services;
    }
}
