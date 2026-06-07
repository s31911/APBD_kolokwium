namespace APBD___06_EFC_Code_first_API.Entities;

public class Payments
{
    public int PaymentId  { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string PaymentStatus { get; set; } = string.Empty;

    public int OrderId { get; set; }
    public Orders Order { get; set; } = null!;

}