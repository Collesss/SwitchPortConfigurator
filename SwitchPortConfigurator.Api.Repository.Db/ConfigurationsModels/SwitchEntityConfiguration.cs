using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwitchPortConfigurator.Api.Repository.Entities;

namespace SwitchPortConfigurator.Api.Repository.Db.ConfigurationsModels
{
    public class SwitchEntityConfiguration : IEntityTypeConfiguration<SwitchEntity>
    {
        public void Configure(EntityTypeBuilder<SwitchEntity> builder)
        {
            
            builder.ToTable(builder => {
                builder.HasCheckConstraint("CK_Switches_MacAddress", "\"MacAddress\" ~* '^([A-F0-9]{2}-){5}([A-F0-9]{2})$'");
                builder.HasCheckConstraint("CK_Switches_IPAddress", @"""IPAddress"" ~* '^((25[0-5]|2[0-4]\d|1\d{2}|[1-9]\d|\d)\.){3}(25[0-5]|2[0-4]\d|1\d{2}|[1-9]\d|\d)$'");
            });
            
            builder.HasKey(swit => swit.Id);

            builder.HasIndex(swit => swit.Name)
                .IsUnique();
            builder.Property(swit => swit.Name)
                .IsRequired();

            builder.HasIndex(swit => swit.IPAddress)
                .IsUnique();
            builder.Property(swit => swit.IPAddress)
                .IsRequired();

            builder.HasIndex(swit => swit.MacAddress)
                .IsUnique();
            builder.Property(swit => swit.MacAddress)
                .IsRequired();

            builder.HasOne<LocationEntity>()
                .WithMany()
                .HasForeignKey(swit => swit.LocationId)
                .HasPrincipalKey(loc => loc.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<ModelEntity>()
                .WithMany()
                .HasForeignKey(swit => swit.ModelId)
                .HasPrincipalKey(mod => mod.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
