
using Application.Utilities.Mediator;

namespace Application.UseCases.Products.Commands.StockAdjustment;

public record StockAdjustmentCommand(Guid IdProduct, int Delta): IRequest;
