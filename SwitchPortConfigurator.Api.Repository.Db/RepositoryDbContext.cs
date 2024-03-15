using Microsoft.EntityFrameworkCore;
using SwitchPortConfigurator.Api.Repository.Db.ConfigurationsModels;
using SwitchPortConfigurator.Api.Repository.Entities;

namespace SwitchPortConfigurator.Api.Repository.Db
{
    public class RepositoryDbContext : DbContext
    {
        public DbSet<SwitchEntity> Switches { get; set; }


        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SwitchEntityConfiguration());
        }
    }
}
