namespace APBD___06_EFC_Code_first_API.Entities;

public class Users
{
    public int UserId  { get; set; }
    
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; }= string.Empty;
    public string PasswordHash { get; set; }= string.Empty;
    public DateTime CreatedAt { get; set; }

    public ICollection<Orders> Orders { get; set; } = [];
    
}