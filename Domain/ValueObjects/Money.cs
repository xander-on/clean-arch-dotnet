


using Domain.Exceptions;

namespace Domain.ValueObjects;

public class Money
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; } = default!;

    private Money (decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }


    public static Money Create(decimal amount, string currency = "USD")
    {
        if(amount < 0)
            throw new BusinessRuleException("Amount cannot be negative.");

        if(string.IsNullOrEmpty(currency))
            throw new BusinessRuleException("Currency cannot be null or empty.");

        return new Money(amount, currency);
    }
}