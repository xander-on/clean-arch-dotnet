


namespace Application.UseCases.Products.Queries.GetProductById;

public record ProductDetailDto(
    Guid Id, 
    string Name,
    string? Description,
    decimal Price,
    string Currency,
    int StockQuantity,
    bool IsActive
);