

using Application.Contracts;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DI
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>( 
            options => options.UseSqlServer("name=DefaultConnection")
        );
        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
}