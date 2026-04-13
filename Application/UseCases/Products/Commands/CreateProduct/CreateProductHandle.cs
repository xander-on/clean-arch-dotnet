


using Application.Contracts;
using Application.Products.Commands.CreateProduct;
using Application.Utilities.Mediator;
using Domain.Entities;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Application.UseCases.Products.Commands.CreateProduct;

public class CreateProductUseCase(IProductRepository productRepository)
    : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand command)
    {
        var existingProduct = await productRepository.Exists(command.Name);
        if (existingProduct )
            throw new BusinessRuleExceptions("Product name already exists.");

        var money = Money.Create(command.Price, command.Currency);
        var stockQuantity = StockQuantity.Create(command.StockQuantity);

        var product = Product.Create(
            command.Name, 
            command.Description ?? string.Empty, 
            money, 
            stockQuantity
        );

        await productRepository.Add(product);
        return product.Id;
    }
}