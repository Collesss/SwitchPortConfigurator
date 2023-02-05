using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwitchPortConfigurator.Api.Repository.Entities;

namespace SwitchPortConfigurator.Api.Repository.Db.ConfigurationsModels
{
    public class ModelEntityConfiguration : IEntityTypeConfiguration<ModelEntity>
    {
        public void Configure(EntityTypeBuilder<ModelEntity> builder)
        {
            builder.ToTable(builder => builder.HasCheckConstraint("CK_Models_CountPorts", "\"CountPorts\" > 0"));

            builder.HasKey(mod => mod.Id);

            builder.HasIndex(mod => mod.Model)
                .IsUnique();
            builder.Property(mod => mod.Model)
                .IsRequired();

            builder.HasOne<ManufacturerEntity>()
                .WithMany()
                .HasForeignKey(mod => mod.ManufacturerId)
                .HasPrincipalKey(manuf => manuf.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
