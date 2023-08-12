using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Business.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(product => product.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(product => product.Image)
                .HasMaxLength(1000);

            builder.Property(product => product.Price)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(product => product.Brand)
                .WithMany()
                .HasForeignKey(product => product.BrandId);

            builder.HasOne(product => product.Category)
                .WithMany()
                .HasForeignKey(product => product.CategoryId);
        }
    }
}
