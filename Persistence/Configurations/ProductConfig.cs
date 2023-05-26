using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("product");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("Id");
			builder.Property(x => x.Deleted).HasColumnName("Deleted");

			builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(250).IsRequired();
			builder.Property(x => x.Sku).HasColumnName("Sku").HasMaxLength(50).IsRequired();
			builder.Property(x => x.UnitPrice).HasColumnName("UnitPrice");
			builder.Property(x => x.Stock).HasColumnName("Stock");
			builder.Property(x => x.CategoryId).HasColumnName("CategoryId");

			builder.HasOne(x => x.Category)
				.WithMany(x => x.Products)
				.HasForeignKey(x => x.CategoryId)
				.HasPrincipalKey(x => x.Id);
		}
	}
}