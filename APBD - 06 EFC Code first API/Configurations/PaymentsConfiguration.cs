using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD___06_EFC_Code_first_API.Entities;

public class PaymentsConfiguration : IEntityTypeConfiguration<Payments>
{
    public void Configure(EntityTypeBuilder<Payments> builder)
    {
        builder.HasKey(c =>c.PaymentId);
        builder.Property(x => x.PaymentMethod).HasMaxLength(100);
        builder.Property(x => x.PaymentMethod).HasMaxLength(100);
        
        // boje sie ze to ma tendencje buggo genne
        
        builder.HasOne(c=>c.Order)
            .WithMany(pc => pc.Payments)
            .HasForeignKey(f=>f.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        
     
    }
}