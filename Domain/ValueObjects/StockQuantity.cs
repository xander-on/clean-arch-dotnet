

using Domain.Exceptions;

namespace Domain.ValueObjects;
public class StockQuantity
{
    public int Quantity { get; private set; }

    private StockQuantity(int quantity)
    {
        Quantity = quantity;
    }

    public static StockQuantity Create(int quantity)
    {
        if (quantity < 0)
            throw new BusinessRuleException("Stock quantity cannot be negative.");

        return new StockQuantity(quantity);
    }
}
