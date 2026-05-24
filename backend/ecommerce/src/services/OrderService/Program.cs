using Microsoft.EntityFrameworkCore;
using OrderService.Datas;
using OrderService.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddGrpc();

// db context for order
builder.Services.AddDbContext<OrderDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("OrderDb")));

var app = builder.Build();


app.MapGrpcService<GreeterService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();