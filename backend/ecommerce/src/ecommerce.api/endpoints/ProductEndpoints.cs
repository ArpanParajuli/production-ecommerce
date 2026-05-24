using ecommerce.api.dtos;

namespace ecommerce.api.endpoints;

public static class ProductEndpoints
{
    public static void MapProductsEndpoints(this WebApplication app)
    {
        app.MapGet("/products", GetProducts);


        app.MapPost("/products/{id}", GetProductById);


        app.MapPost("/products/create", CreateProduct);
        
    }


    static IResult GetProductById(Guid id)
    {
        return Results.Json(new { id });
    }

    static IResult CreateProduct(CreateProductDto dto)
    {
        return Results.Json(new { dto});
    }

    static IResult GetProducts()
    {
        return Results.Json(("prodcuts"));
    }
}