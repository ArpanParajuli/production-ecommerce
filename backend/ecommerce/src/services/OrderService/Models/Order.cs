namespace OrderService.Models;

public class Order
{
    public int Id { get; set; }

    public Guid Pid { get; set; } = Guid.Empty;
    
    public int UserId { get; set; }
    
    public string UserName { get; set; }
    
    public string UserEmail { get; set; }
    
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;
    
    public string ProductDescription { get; set; } = string.Empty;
    
    public int Quantity { get; set; }
    
    public decimal TotalPrice { get; set; }
}