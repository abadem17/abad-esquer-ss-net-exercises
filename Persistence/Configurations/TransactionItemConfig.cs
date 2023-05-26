using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
	public class TransactionItemConfig : IEntityTypeConfiguration<TransactionItem>
	{
		public void Configure(EntityTypeBuilder<TransactionItem> builder)
		{
			builder.ToTable("sale_transaction_item");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("Id");
			builder.Property(x => x.Deleted).HasColumnName("Deleted");

			builder.Property(x => x.SaleTransactionId).HasColumnName("SaleTransactionId");
			builder.Property(x => x.ProductId).HasColumnName("ProductId");
			builder.Property(x => x.Quantity).HasColumnName("Quantity");
			builder.Property(x => x.UnitPrice).HasColumnName("CurrentUnitPrice");
			builder.Property(x => x.Discount).HasColumnName("Discount");
			builder.Property(x => x.Tax).HasColumnName("Tax");

			builder.HasOne(x => x.SaleTransaction)
				.WithMany(x => x.TransactionItems)
				.HasForeignKey(x => x.SaleTransactionId)
				.HasPrincipalKey(x => x.Id);

			builder.HasOne(x => x.Product)
				.WithMany(x => x.TransactionItems)
				.HasForeignKey(x => x.ProductId)
				.HasPrincipalKey(x => x.Id);
		}
	}
}