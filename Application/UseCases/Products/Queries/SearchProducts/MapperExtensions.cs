

using Domain.Entities;

namespace Application.UseCases.Products.Queries.SearchProducts;

public static class MapperExtensions
{
    public static SearchProductsDto toDto(this Product product)
    {
        return new SearchProductsDto(
            product.Id,
            product.Name,
            product.Price.Amount,
            product.Price.Currency
        );
    }
}