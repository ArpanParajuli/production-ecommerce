using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Datas;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {

            entity.HasKey(e => e.Id);
           
            
            
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Quantity).IsRequired();
            
            
            // user 
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.UserEmail).IsRequired().HasMaxLength(1000);
            entity.Property(e => e.UserName).IsRequired().HasMaxLength(1000);
            
            
            // product
            
            entity.Property(e=> e.ProductName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.ProductDescription).IsRequired().HasMaxLength(1000);
            entity.Property(e=> e.ProductId).IsRequired();


        });
    }
    
    
    public DbSet<Order> Orders { get; set; }
}