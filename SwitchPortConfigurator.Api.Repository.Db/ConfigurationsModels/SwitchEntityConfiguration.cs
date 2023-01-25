using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwitchPortConfigurator.Api.Repository.Entities;

namespace SwitchPortConfigurator.Api.Repository.Db.ConfigurationsModels
{
    public class SwitchEntityConfiguration : IEntityTypeConfiguration<SwitchEntity>
    {
        public void Configure(EntityTypeBuilder<SwitchEntity> builder)
        {
            // need Constarins for IpAdress
            builder.ToTable(builder => { 
                builder.HasCheckConstraint("MacAddress", "MacAddress ~ '^([A-F0-9]{2}-){5}([A-F0-9]{2})$'"); 
            });

            builder.ToTable(builder => builder.HasCheckConstraint("CountPorts", "CountPorts > 0"));

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
