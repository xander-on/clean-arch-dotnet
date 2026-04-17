

using Application.Contracts;
using Application.Exceptions;
using Application.Utilities.Mediator;
using Domain.ValueObjects;

namespace Application.UseCases.Products.Commands.UpdateProduct;

public class UpdateProductHandle(IProductRepository repository) : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand command)
    {
        var product = await repository.GetById(command.Id);

        if (product is null) throw new NotFoundException();

        var money = Money.Create(command.Price, command.Currency);
        product.Update(command.Name, command.Description, money, command.IsActive);

        await repository.Update(product);
    }
}