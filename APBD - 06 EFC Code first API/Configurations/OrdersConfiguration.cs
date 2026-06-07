using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD___06_EFC_Code_first_API.Entities;

public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder.HasKey(p => p.OrderId);
        builder.Property(x => x.Status).HasMaxLength(100);
        builder.Property(x=> x.TotalAmount).HasColumnType("decimal(5,2)");
        builder.Property(x=> x.OrderDate).HasColumnType("datetime");
        
        builder.HasOne(c=>c.user)
            .WithMany(c=>c.Orders)
            .HasForeignKey(ct => ct.Users_UserId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}