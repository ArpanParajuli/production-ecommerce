using ecommerce.api.endpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer(); // for minimal api

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Keyclaok:Authority"];
        options.Audience = builder.Configuration["Keyclaok:Audience"];
        
        options.RequireHttpsMetadata = false;
        
        options.TokenValidationParameters.ValidateAudience = true;
    });

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapOrdersEndpoint();
app.MapProductsEndpoints();





app.Run();