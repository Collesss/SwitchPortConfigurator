using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwitchPortConfigurator.Api.Repository.Entities;

namespace SwitchPortConfigurator.Api.Repository.Db.ConfigurationsModels
{
    public class LocationEntityConfiguration : IEntityTypeConfiguration<LocationEntity>
    {
        public void Configure(EntityTypeBuilder<LocationEntity> builder)
        {
            builder.ToTable(builder => builder.HasCheckConstraint("CK_Locations_Cabinet", "\"Cabinet\" > 0"));

            builder.HasKey(loc => loc.Id);
            //builder.HasCheckConstraint("Cabinet", "Cabinet > 0");

            builder.HasOne<AreaEntity>()
                .WithMany()
                .HasForeignKey(loc => loc.AreaId)
                .HasPrincipalKey(area => area.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
