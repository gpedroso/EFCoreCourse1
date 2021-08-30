using EFCoreCourse.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCourse.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItens");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Quantity).HasDefaultValue(0).IsRequired();
            builder.Property(p => p.Value).HasDefaultValue(0).IsRequired();
            builder.Property(p => p.Discount).HasDefaultValue(0).IsRequired();
        }
    }
}