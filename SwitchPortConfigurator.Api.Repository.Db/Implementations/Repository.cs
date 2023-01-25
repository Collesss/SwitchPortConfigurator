using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwitchPortConfigurator.Api.Repository.Interfaces;

namespace SwitchPortConfigurator.Api.Repository.Db.Implementations
{
    public abstract class Repository<TEntity, VId, EDbContext> : IRepository<TEntity, VId>
        where TEntity : class
        where EDbContext : DbContext
    {
        private readonly ILogger<Repository<TEntity, VId, EDbContext>> _logger;
        private readonly DbContext _dbContext;

        public Repository(ILogger<Repository<TEntity, VId, EDbContext>> logger, DbContext dbContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Delete(VId id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(VId id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
