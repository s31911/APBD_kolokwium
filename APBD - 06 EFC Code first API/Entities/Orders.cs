namespace APBD___06_EFC_Code_first_API.Entities;

public class Orders
{
    public int OrderId  { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public int Users_UserId { get; set; }
    public Users user { get; set; } = null!;
    public ICollection<OrderItems> OrderItemsCollection { get; set; } = [];
    public ICollection<Payments> Payments { get; set; } = [];

}