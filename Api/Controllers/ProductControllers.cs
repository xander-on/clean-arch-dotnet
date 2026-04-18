


using Api.Dtos;
using Application.Products.Commands.CreateProduct;
using Application.UseCases.Products.Commands.StockAdjustment;
using Application.UseCases.Products.Commands.UpdateProduct;
using Application.UseCases.Products.Queries.GetProductById;
using Application.UseCases.Products.Queries.SearchProducts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(IMediator mediator): ControllerBase
{

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailDto>> Get(
        [FromRoute] Guid id
    )
    {
        var query = new GetProductByIdQuery(id);
        return await mediator.Send(query);
    }


    [HttpGet("search")]
    public async Task<ActionResult<List<SearchProductsDto>>> Search(
        [FromQuery] string? name,
        [FromQuery] bool? isActive
    )
    {
        var query = new SearchProductsQuery(name, isActive);
        return await mediator.Send(query);
    }

    

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
        return CreatedAtAction(nameof(Get), new { id }, id);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateProductDto dto
    )
    {
        var command = new UpdateProductCommand(
            id,
            dto.Name,
            dto.Description,
            dto.Price,
            dto.Currency,
            dto.IsActive
        );

        await mediator.Send(command);
        return NoContent();
    }


    [HttpPost("{id}/stock")]
    public async Task<ActionResult> StockAdjustment(
        [FromRoute] Guid id,
        [FromBody] StockAdjustmentDto dto
    )
    {
        var command = new StockAdjustmentCommand(id, dto.Delta);
        await mediator.Send(command);
        return NoContent();
    }
}