using ecommerce.api.endpoints;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer(); // for minimal api

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}



app.MapOrdersEndpoint();
app.MapProductsEndpoints();



app.Run();