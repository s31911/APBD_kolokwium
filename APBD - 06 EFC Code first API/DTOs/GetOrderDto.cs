using APBD___06_EFC_Code_first_API.Entities;

namespace APBD___06_EFC_Code_first_API.DTOs;

public class GetOrderDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public String Status { get; set; } = string.Empty;
    public int TotalAmount { get; set; }
    public String User { get; set; } = string.Empty;
    public ICollection<PaymentsDTO> Payments = []; 
    public ICollection<OrderItemsDTO> OrderItems = []; 
        
        
        
        public class PaymentsDTO
        {
            public int PaymentId { get; set; }
            public String PaymentMethod { get; set; }
            public decimal Amount { get; set; }
            public string Status { get; set; }
        }
        public class OrderItemsDTO
        {
            public ProductDto Product{ get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
    }

        public class ProductDto
        {
            public int ProductsId { get; set; }
            public string Name  { get; set; } = string.Empty;
            public string Description  { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public int StockQuantity { get; set; }
        }
        
        
}