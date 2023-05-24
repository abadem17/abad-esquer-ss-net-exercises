using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
	public class SchoolConfig : IEntityTypeConfiguration<School>
	{
		public void Configure(EntityTypeBuilder<School> builder)
		{
			builder.ToTable("school");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("Id");
			builder.Property(x => x.Deleted).HasColumnName("Deleted");
		}
	}
}
