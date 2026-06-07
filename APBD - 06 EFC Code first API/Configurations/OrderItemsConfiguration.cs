using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD___06_EFC_Code_first_API.Entities;

public class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItems>
{
    public void Configure(EntityTypeBuilder<OrderItems> builder)
    {
        builder.HasKey(c => new{c.OrderId, c.ProductId});
        
        builder.HasOne(c=>c.Product)
            .WithMany(c=>c.OrderItemsCollection)
            .HasForeignKey(ct => ct.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(c=>c.Order)
            .WithMany(c=>c.OrderItemsCollection)
            .HasForeignKey(ct => ct.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}