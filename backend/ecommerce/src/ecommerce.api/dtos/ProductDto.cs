namespace ecommerce.api.dtos;

public record CreateProductDto(string Name, string Description ,decimal Price);

public record UpdateProductDto(Guid Pid, string Name, string Description, decimal Price);

public record GetProductById(Guid Pid);

