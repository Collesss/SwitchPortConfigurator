using Microsoft.Extensions.Logging;
using SwitchPortConfigurator.Api.Repository.Entities;
using SwitchPortConfigurator.Api.Repository.Interfaces;

namespace SwitchPortConfigurator.Api.Repository.Db.Implementations
{
    public class ModelRepository : Repository<ModelEntity, int, RepositoryDbContext>, IModelRepository
    {
        public ModelRepository(ILogger<Repository<ModelEntity, int, RepositoryDbContext>> baseRepositoryLogger,
            RepositoryDbContext dbContext) : base(baseRepositoryLogger, dbContext)
        {
        }
    }
}
