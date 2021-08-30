using EFCoreCourse.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCourse.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.BeginIn).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.OrderStatus).HasConversion<string>();
            builder.Property(p => p.ShippintType).HasConversion<int>();
            builder.Property(p => p.Note).HasColumnType("VARCHAR(512)");

            builder.HasMany(p => p.Itens)
                .WithOne(p => p.Order)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}