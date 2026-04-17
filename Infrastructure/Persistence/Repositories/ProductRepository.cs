


using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public async Task Add(Product product)
    {
        context.Add(product);
        await context.SaveChangesAsync();
    }

    public async Task<bool> Exists(string name)
        => await context.Products.AnyAsync(x => x.Name == name);


    public async Task<Product?> GetById(Guid id)
        => await context.Products.FirstOrDefaultAsync(x => x.Id == id);


    public async Task Update(Product product)
    {
        context.Update(product);
        await context.SaveChangesAsync();
    }
}