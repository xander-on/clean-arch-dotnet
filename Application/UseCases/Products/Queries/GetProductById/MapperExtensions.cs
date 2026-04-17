

using Domain.Entities;

namespace Application.UseCases.Products.Queries.GetProductById;

public static class MapperExtensions
{
    public static ProductDetailDto toDto(this Product product)
    {
        return new ProductDetailDto(
            product.Id,
            product.Name,
            product.Description,
            product.Price.Amount,
            product.Price.Currency,
            product.StockQuantity.Quantity,
            product.Activo
        );
    }
}