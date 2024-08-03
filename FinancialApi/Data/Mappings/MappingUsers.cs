using FinancialApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialApi.Data.Mappings
{
    public class MappingUsers : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Username)
                .HasColumnName("username");

            builder.Property(e => e.Role)
                .HasColumnName("role");

            builder.Property(e => e.Password)
                .HasColumnName("password");

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
        }
    }
}