


using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;

public class CreateProductDto
{
    [Required]
    [MaxLength(200)]
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public required string Currency { get; set; }
    public int StockQuantity { get; set; }
}