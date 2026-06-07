namespace APBD___06_EFC_Code_first_API.Entities;

public class Products
{
    public int ProductsId { get; set; }
    public string Name  { get; set; } = string.Empty;
    public string Description  { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    
    public ICollection<OrderItems> OrderItemsCollection { get; set; } = [];
}