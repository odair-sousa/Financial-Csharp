using FinancialApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialApi.Data.Mappings
{
    public class MappingCountrie : IEntityTypeConfiguration<Countrie>
    {
        public void Configure(EntityTypeBuilder<Countrie> builder)
        {
            builder.ToTable("countrie");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasColumnName("name");

            builder.Property(e => e.Deleted)
                .HasColumnName("deleted");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(e => e.AlteredAt)
                .HasColumnName("altered_at");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");
        }
    }
}