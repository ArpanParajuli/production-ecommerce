namespace ecommerce.api.endpoints;

public static class OrderEndpoints
{
    public static void MapOrdersEndpoint(this IEndpointRouteBuilder app)
    {
        var appgroup = app.MapGroup("/orders");
        
        appgroup.MapGet("/status", () =>
        {

        });


        appgroup.MapPost("/create", () =>
        {
          
        });
    }
}