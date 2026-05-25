using Microsoft.EntityFrameworkCore;
using OrderService.Datas;
using OrderService.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddGrpc();

// db context for order
builder.Services.AddDbContext<OrderDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


app.MapGrpcService<GreeterService>();
app.MapGrpcService<OrderGrpcsService>();

app.MapGet("/", () => "Server running");
app.Run();