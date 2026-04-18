



using Application.Contracts;
using Application.Utilities.Mediator;
using Domain.Entities;

namespace Application.UseCases.Products.Queries.SearchProducts;

public class SearchProductsHandle(IProductRepository repository)
    : IRequestHandler<SearchProductsQuery, List<SearchProductsDto>>
{
    public async Task<List<SearchProductsDto>> Handle(SearchProductsQuery request)
    {
        List<Product> products = await repository.Search(request.Name, request.IsActive);

        var productsDto = products.Select(p => p.toDto()).ToList();

        return productsDto;
    }
}