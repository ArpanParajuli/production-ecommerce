using System.Security.Claims;
using ecommerce.api.dtos;
using Grpc.Net.Client;
using ecommerce.api.grpc;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.api.endpoints;

public static class OrderEndpoints
{
    public static void MapOrdersEndpoint(this IEndpointRouteBuilder app)
    {
        var appgroup = app.MapGroup("/orders");
        
        appgroup.MapGet("/status", (ClaimsPrincipal claims) =>
        {
            var result = new
            {
                Name = claims.Identity?.Name,
                IsAuthenticated = claims.Identity?.IsAuthenticated,
                Claims = claims.Claims.Select(c => new
                {
                    c.Type,
                    c.Value
                })
            };
            
            

            return Results.Ok(result);
        }).RequireAuthorization();
        

        appgroup.MapPost("/create", async (ClaimsPrincipal claims , [FromBody] CreateOrderDto orderdto) =>
        {
            
        
           using var channel = GrpcChannel.ForAddress("http://localhost:5048");
           
           var client = new OrderServiceGrpc.OrderServiceGrpcClient(channel);

           var email =
               claims.FindFirst("preferred_username")?.Value ??
               claims.FindFirst("email")?.Value ??
               claims.FindFirst(ClaimTypes.Email)?.Value ??
               claims.FindFirst("emailaddress")?.Value ??
               "arpanparajuli07@gmail.com";
           
           var name  = claims.FindFirst("name")?.Value ?? "guestuser";
           

              


           var request = new CreateOrderRequest
           {
              UserId = 1,
              UserName = name,
              UserEmail = email,
              ProductId = orderdto.ProductId,
              ProductName = orderdto.ProductName,
              ProductDescription = orderdto.ProductDescription,
              ProductQuantity =  orderdto.Quantity,
              Price = orderdto.UnitPrice
              
           };

           var response = await client.CreateOrderAsync(request);
             return Results.Ok(response);
        });
    }
}

