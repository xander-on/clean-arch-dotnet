using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configs;

public class ProductConfig: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(prop => prop.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(prop => prop.Name).IsUnique();

        builder.Property(x => x.Description)
            .HasMaxLength(2000);

        builder.ComplexProperty(prop => prop.Price, action =>
        {
            action.Property(p => p.Amount)
                .HasColumnName("Price")
                .HasPrecision(18, 2);

            action.Property(p => p.Currency)
                .HasColumnName("Currency");
        });


        builder.ComplexProperty(prop => prop.StockQuantity, action =>
        {
            action.Property(p => p.Quantity)
                .HasColumnName("Stock");
        });
    }
}