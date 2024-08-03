using FinancialApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialApi.Data.Mappings
{
    public class MappingPeople : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.ToTable("peoples");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasColumnName("name");

            builder.Property(e => e.DateOfBirth)
                .HasColumnName("date_of_birth");

            builder.Property(e => e.CPF)
                .HasColumnName("cnpj");

            builder.Property(e => e.CNPJ)
                .HasColumnName("cnpj");

            builder.Property(e => e.RG)
                .HasColumnName("rg");

            builder.Property(e => e.Deleted)
                .HasColumnName("deleted");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(e => e.AlteredAt)
                .HasColumnName("altered_at");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.Property(e => e.Email)
                .HasColumnName("email");
        }
    }
}