namespace OrderService.Models;

public class Order
{
    public int Id { get; set; }

    public Guid Pid { get; set; } = Guid.Empty;
    
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;
    
    public string ProductDescription { get; set; } = string.Empty;
    
    public int Quantity { get; set; }
    
    public decimal TotalPrice { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public DateTime DeliveryDate { get; set; }
    
    public bool IsVerified { get; set; }
    
    public bool IsPaid { get; set; }
    
    public bool IsShipped { get; set; }
    
    public bool IsCompleted { get; set; }



    public Order(
        int userId,
        string userName,
        string userEmail,
        int productId,
        string productName,
        string productDescription,
        int quantity,
        decimal totalPrice)
    {
        UserId = userId;
        UserName = userName;
        UserEmail = userEmail;
        ProductId = productId;
        ProductName = productName;
        ProductDescription = productDescription;
        Quantity = quantity;
        TotalPrice = totalPrice;

        OrderDate = DateTime.UtcNow;
        DeliveryDate = DateTime.UtcNow.AddDays(7);

        IsVerified = false;
        IsPaid = false;
        IsShipped = false;
        IsCompleted = false;
    }
}