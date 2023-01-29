using Microsoft.Extensions.Logging;
using SwitchPortConfigurator.Api.Repository.Entities;
using SwitchPortConfigurator.Api.Repository.Interfaces;

namespace SwitchPortConfigurator.Api.Repository.Db.Implementations
{
    public class ManufacturerRepository : Repository<ManufacturerEntity, int, RepositoryDbContext>, IManufacturerRepository
    {
        public ManufacturerRepository(ILogger<Repository<ManufacturerEntity, int, RepositoryDbContext>> baseRepositoryLogger,
            RepositoryDbContext dbContext) : base(baseRepositoryLogger, dbContext)
        {
        }
    }
}
