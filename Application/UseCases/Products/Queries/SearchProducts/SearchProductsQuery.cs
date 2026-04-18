


using Application.Utilities.Mediator;

namespace Application.UseCases.Products.Queries.SearchProducts;

public record SearchProductsQuery(
    string? Name,
    bool? IsActive
) : IRequest<List<SearchProductsDto>>;

