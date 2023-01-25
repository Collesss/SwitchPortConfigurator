using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwitchPortConfigurator.Api.Repository.Entities;

namespace SwitchPortConfigurator.Api.Repository.Db.ConfigurationsModels
{
    public class AreaEntityConfiguration : IEntityTypeConfiguration<AreaEntity>
    {
        public void Configure(EntityTypeBuilder<AreaEntity> builder)
        {
            builder.HasKey(area => area.Id);

            builder.HasIndex(area => area.Name)
                .IsUnique();
            builder.Property(area => area.Name)
                .IsRequired();
        }
    }
}
