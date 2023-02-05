using Microsoft.Extensions.Logging;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Interfaces;
using SwitchPortConfigurator.Api.Repository.Entities;
using SwitchPortConfigurator.Api.Repository.Interfaces;

namespace SwitchPortConfigurator.Api.Repository.Db.Implementations
{
    public class LocationRepository : Repository<LocationEntity, int, RepositoryDbContext>, ILocationRepository
    {
        public LocationRepository(ILogger<Repository<LocationEntity, int, RepositoryDbContext>> baseRepositoryLogger,
            IErrorHandlerDb errorHandlerDb, RepositoryDbContext dbContext) : base(baseRepositoryLogger, errorHandlerDb, dbContext)
        {
        }
    }
}
