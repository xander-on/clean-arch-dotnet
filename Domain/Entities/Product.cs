
using Domain.ValueObjects;
using Domain.Exceptions;

namespace Domain.Entities;


public class Product
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = string.Empty;
    public Money Price { get; private set; } = Money.Create(0);
    public StockQuantity StockQuantity { get; private set; } = StockQuantity.Create(0);
    public bool Activo { get; private set; } = true;


    public static Product Create(string name, string description, Money price, StockQuantity stockQuantity)
    {
        NameValidator(name);

        return new Product
        {
            Name = name,
            Description = description,
            Price = price,
            StockQuantity = stockQuantity
        };
    }



    public void Update(string name, string? description, Money price, bool isActive)
    {
        NameValidator(name);
        
        Name = name;
        Description = description ?? Description;
        Price = price;
        Activo = isActive;
    }


    private static void NameValidator(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new BusinessRuleException("Product name cannot be null or empty.");

        if (name.Trim().Length > 200)
            throw new BusinessRuleException("Product name cannot exceed 200 characters.");
    }



    public void StockAdjustment(int delta)
    {
        var newValue = StockQuantity.Quantity + delta;

        if (newValue < 0)
            throw new BusinessRuleException("Stock quantity cannot be negative.");

        StockQuantity = StockQuantity.Create(newValue);
    }
}