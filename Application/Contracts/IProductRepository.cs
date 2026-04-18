using Domain.Entities;

namespace Application.Contracts;


public interface IProductRepository
{
    Task Add(Product product);
    Task<bool> Exists(string nombre);
    Task<Product?> GetById(Guid id);
    Task Update(Product product);
    Task<List<Product>> Search(string? name, bool? isActive);
}