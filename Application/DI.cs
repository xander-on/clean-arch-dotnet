

using Application.Products.Commands.CreateProduct;
using Application.UseCases.Products.Commands.CreateProduct;
using Application.Utilities.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DI
{
    public static IServiceCollection AddApplication( this IServiceCollection services)
    {
        services.AddTransient<IMediator, SimpleMediator>();
        services.AddScoped<IRequestHandler<CreateProductCommand, Guid>, CreateProductUseCase>();
        return services;
    }
}