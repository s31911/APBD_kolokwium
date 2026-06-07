namespace APBD___06_EFC_Code_first_API.Entities;

public class OrderItems
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public Orders Order { get; set; } = null!;
    public Products Product = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    
}