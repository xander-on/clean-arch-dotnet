
namespace Application.UseCases.Products.Queries.SearchProducts;

public record SearchProductsDto(
    Guid Id,
    string Name,
    decimal Price,
    string Currency
    // bool IsActive
);