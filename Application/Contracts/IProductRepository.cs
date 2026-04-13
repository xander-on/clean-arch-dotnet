using Domain.Entities;

namespace Application.Contracts;


public interface IProductRepository
{
    Task Add(Product product);
    Task<bool> Exists(string nombre);
}