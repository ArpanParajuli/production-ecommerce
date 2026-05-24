namespace ecommerce.api.dtos;

public record CreateOrderDto();

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