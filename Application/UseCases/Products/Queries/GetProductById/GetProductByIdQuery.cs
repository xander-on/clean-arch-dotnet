


using Application.Utilities.Mediator;

namespace Application.UseCases.Products.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id): IRequest<ProductDetailDto>;