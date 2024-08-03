using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialApi.Data.Mappings
{
    public class MappingMonthlyBills : IEntityTypeConfiguration<MonthlyBills>
    {
        public void Configure(EntityTypeBuilder<MonthlyBills> builder)
        {
            builder.ToTable("monthly_bills");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasColumnName("name");

            builder.Property(e => e.Description)
                .HasColumnName("description");

            builder.Property(e => e.Entries)
                .HasColumnName("entries");

            builder.Property(e => e.Exits)
                .HasColumnName("exits");

            builder.Property(e => e.DueDate)
                .HasColumnName("due_date");

            builder.Property(e => e.Deleted)
                .HasColumnName("deleted");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(e => e.AlteredAt)
                .HasColumnName("altered_at");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.Property(e => e.PeopleId)
                .HasColumnName("people_id");

            builder.Property(e => e.BalancePeriodId)
                .HasColumnName("balance_period_id");
        }
    }
}