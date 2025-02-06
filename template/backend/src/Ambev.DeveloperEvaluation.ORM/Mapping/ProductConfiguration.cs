using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Price).IsRequired().HasPrecision(2);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
        builder.Property(p => p.Image).IsRequired().HasMaxLength(200);
        builder.Property(p => p.CategoryId).IsRequired();
        builder.OwnsOne(p => p.Rating, navigationBuilder =>
        {
            navigationBuilder.Property(r => r.Rate);
            navigationBuilder.Property(r => r.Count).HasColumnName("reviews_count");
        });
        
        builder.HasMany(p => p.Reviews).WithOne().HasForeignKey(r => r.ProductId);
    }
}