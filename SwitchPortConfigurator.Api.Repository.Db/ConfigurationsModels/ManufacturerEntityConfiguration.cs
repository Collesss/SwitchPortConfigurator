using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwitchPortConfigurator.Api.Repository.Entities;

namespace SwitchPortConfigurator.Api.Repository.Db.ConfigurationsModels
{
    public class ManufacturerEntityConfiguration : IEntityTypeConfiguration<ManufacturerEntity>
    {
        public void Configure(EntityTypeBuilder<ManufacturerEntity> builder)
        {
            builder.HasKey(manuf => manuf.Id);

            builder.HasIndex(manuf => manuf.Manufacturer)
                .IsUnique();
            builder.Property(manuf => manuf.Manufacturer)
                .IsRequired();
        }
    }
}
