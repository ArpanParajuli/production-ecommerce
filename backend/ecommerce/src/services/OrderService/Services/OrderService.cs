using OrderService.Datas;
using Grpc.Core;
using OrderService.Models;

namespace OrderService.Services;

public class OrderGrpcsService : OrderServiceGrpc.OrderServiceGrpcBase
{

    private readonly ILogger<OrderGrpcsService> _logger;

    private readonly OrderDbContext _context;

    public OrderGrpcsService(OrderDbContext context ,  ILogger<OrderGrpcsService> logger)
    {
        _context = context;
        _logger = logger;
    }


    public override async Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"{request.ProductName} {request.UserName}", request);


        var order = new Order(
            request.UserId,
            request.UserName,
            request.UserEmail,
            request.ProductId,
            request.ProductName,
            request.ProductDescription,
            request.ProductQuantity,
            (decimal)request.Price
        );

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        
        Console.WriteLine("Order created in db");

        return new CreateOrderResponse
        {
            OrderId = order.Id,
            UserId = order.UserId,
            UserName = order.UserName,
            ProductId = order.ProductId,
            ProductName = order.ProductName,
            ProductDescription = order.ProductDescription,
            ProductQuantity = order.Quantity,
            Price = (float)order.TotalPrice,
            DeliverDate = order.DeliveryDate.ToString("yyyy-MM-dd"),
            IsVerified = order.IsVerified

        };


    }

}