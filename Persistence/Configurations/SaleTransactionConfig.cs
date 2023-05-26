using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
	public class SaleTransactionConfig : IEntityTypeConfiguration<SaleTransaction>
	{
		public void Configure(EntityTypeBuilder<SaleTransaction> builder)
		{
			builder.ToTable("sale_transaction");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("Id");
			builder.Property(x => x.Deleted).HasColumnName("Deleted");

			builder.Property(x => x.Date).HasColumnName("Date");
			builder.Property(x => x.PaymentMethodType).HasColumnName("PaymentMethodType");
		}
	}
}