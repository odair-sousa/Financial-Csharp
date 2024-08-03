using FinancialApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialApi.Data.Mappings
{
    public class MappingBalancedPeriods : IEntityTypeConfiguration<BalancePeriod>
    {
        public void Configure(EntityTypeBuilder<BalancePeriod> builder)
        {
            builder.ToTable("balance_periods");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.StartDate)
                .HasColumnName("start_date");

            builder.Property(e => e.EndDate)
                .HasColumnName("end_date");

            builder.Property(e => e.Blocked)
                .HasColumnName("blocked");

            builder.Property(e => e.Consolidated)
                .HasColumnName("consolidated");

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