


using Api.Dtos;
using Application.Products.Commands.CreateProduct;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(IMediator mediator): ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        [FromBody] CreateProductDto dto
    )
    {
        var command = new CreateProductCommand(
            dto.Name,
            dto.Description,
            dto.Price,
            dto.Currency,
            dto.StockQuantity
        );

        var id = await mediator.Send(command);
        return id;
    }
}