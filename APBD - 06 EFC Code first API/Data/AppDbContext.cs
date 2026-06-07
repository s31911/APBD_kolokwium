using APBD___06_EFC_Code_first_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace APBD___06_EFC_Code_first_API.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext() { }

    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Users> Users { get; set; }
    public DbSet<Orders>  Orders { get; set; }
    public DbSet<Payments> Payments { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<OrderItems>  OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}