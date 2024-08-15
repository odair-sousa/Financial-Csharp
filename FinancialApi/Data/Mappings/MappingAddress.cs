using FinancialApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialApi.Data.Mappings
{
    public class MappingAddress : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.NeighborHood)
                .HasColumnName("neighborhood");

            builder.Property(e => e.Street)
                .HasColumnName("street");

            builder.Property(e => e.HouseNumber)
                .HasColumnName("house_number");

            builder.Property(e => e.ZipCode)
                .HasColumnName("zipcode");

            builder.Property(e => e.Deleted)
                .HasColumnName("deleted");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(e => e.AlteredAt)
                .HasColumnName("altered_at");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.Property(e => e.CityId)
                .HasColumnName("city_id");

            builder.Property(e => e.PeopleId)
                .HasColumnName("people_id");
        }
    }
}