


using Application.Contracts;
using Application.Exceptions;
using Application.Utilities.Mediator;

namespace Application.UseCases.Products.Queries.GetProductById;


public class GetProductByIdHandle(IProductRepository repository)
    : IRequestHandler<GetProductByIdQuery, ProductDetailDto>
{
    
    public async Task<ProductDetailDto> Handle(GetProductByIdQuery request)
    {
        var product = await repository.GetById(request.Id);

        if (product is null)
            throw new NotFoundException();

        return product.toDto();

        
    }

    
}