

namespace Api.Dtos;

public class UpdateProductDto : CreateProductDto
{
    public bool IsActive { get; set; }
}