using Microsoft.Extensions.Logging;
using SwitchPortConfigurator.Api.Repository.Entities;
using SwitchPortConfigurator.Api.Repository.Interfaces;

namespace SwitchPortConfigurator.Api.Repository.Db.Implementations
{
    public class LocationRepository : Repository<LocationEntity, int, RepositoryDbContext>, ILocationRepository
    {
        public LocationRepository(ILogger<Repository<LocationEntity, int, RepositoryDbContext>> baseRepositoryLogger,
            RepositoryDbContext dbContext) : base(baseRepositoryLogger, dbContext)
        {
        }
    }
}
