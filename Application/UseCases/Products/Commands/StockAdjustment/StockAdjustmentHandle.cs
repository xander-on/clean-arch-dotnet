
using Application.Contracts;
using Application.Utilities.Mediator;

namespace Application.UseCases.Products.Commands.StockAdjustment;

public class StockAdjustmentHandle( IProductRepository repository ) 
    : IRequestHandler<StockAdjustmentCommand>
{
    public async Task Handle(StockAdjustmentCommand request)
    {
        var product = await repository.GetById(request.IdProduct);

        if (product is null)
            throw new KeyNotFoundException("Product not found.");

        product.StockAdjustment(request.Delta);
        await repository.Update(product);

    }
}