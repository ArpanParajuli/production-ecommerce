namespace ecommerce.api.dtos;

public record CreateOrderDto(int ProductId, string ProductName , string ProductDescription, float UnitPrice ,int Quantity);

public record UpdateOrderDto(
    Guid OrderId
);


public record DeleteOrderDto(
    Guid OrderId
);

public record GetOrderByIdDto(
    Guid OrderId
);
public record GetOrderByUserIdDto(
    Guid UserId
);