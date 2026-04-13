using Application.Utilities.Mediator;

namespace Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name, 
    string? Description, 
    decimal Price,
    string Currency,
    int StockQuantity
):IRequest<Guid>;
