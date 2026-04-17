
using Application.Utilities.Mediator;

namespace Application.UseCases.Products.Commands.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    string? Description,
    decimal Price,
    string Currency,
    bool IsActive
) : IRequest;