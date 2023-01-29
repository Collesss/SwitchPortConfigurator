using Microsoft.Extensions.Logging;
using SwitchPortConfigurator.Api.Repository.Entities;
using SwitchPortConfigurator.Api.Repository.Interfaces;

namespace SwitchPortConfigurator.Api.Repository.Db.Implementations
{
    public class AreaRepository : Repository<AreaEntity, int, RepositoryDbContext>, IAreaRepository
    {
        public AreaRepository(ILogger<Repository<AreaEntity, int, RepositoryDbContext>> baseRepositoryLogger,
            RepositoryDbContext dbContext) : base(baseRepositoryLogger, dbContext)
        {
        }
    }
}
