using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
	public class CategoryConfig : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("category");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("Id");
			builder.Property(x => x.Deleted).HasColumnName("Deleted");

			builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
		}
	}
}
