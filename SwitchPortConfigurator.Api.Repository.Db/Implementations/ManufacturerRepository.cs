using Microsoft.Extensions.Logging;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Interfaces;
using SwitchPortConfigurator.Api.Repository.Entities;
using SwitchPortConfigurator.Api.Repository.Interfaces;

namespace SwitchPortConfigurator.Api.Repository.Db.Implementations
{
    public class ManufacturerRepository : Repository<ManufacturerEntity, int, RepositoryDbContext>, IManufacturerRepository
    {
        public ManufacturerRepository(ILogger<Repository<ManufacturerEntity, int, RepositoryDbContext>> baseRepositoryLogger,
            IErrorHandlerDb errorHandlerDb, RepositoryDbContext dbContext) : base(baseRepositoryLogger, errorHandlerDb, dbContext)
        {
        }
    }
}
