using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Data;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Exceptions;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Interfaces;
using SwitchPortConfigurator.Api.Repository.Exceptions;
using SwitchPortConfigurator.Api.Repository.Interfaces;

namespace SwitchPortConfigurator.Api.Repository.Db.Implementations
{
    public abstract class Repository<TEntity, VId, EDbContext> : IRepository<TEntity, VId>
        where TEntity : class
        where EDbContext : DbContext
    {
        private readonly ILogger<Repository<TEntity, VId, EDbContext>> _logger;
        protected readonly IErrorHandlerDb _errorHandlerDb;
        protected readonly EDbContext _dbContext;

        public Repository(ILogger<Repository<TEntity, VId, EDbContext>> logger, IErrorHandlerDb errorHandlerDb, EDbContext dbContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _errorHandlerDb = errorHandlerDb ?? throw new ArgumentNullException(nameof(errorHandlerDb));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken = default) =>
            await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);

        public async Task<TEntity> GetById(VId id, CancellationToken cancellationToken = default) =>
            await _dbContext.FindAsync<TEntity>(id, cancellationToken);

        public async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken = default)
        {
            TEntity result;

            try
            {
                _logger.LogTrace("Adding entity @{TEntity}.", entity);

                result = (await _dbContext.AddAsync(entity, cancellationToken)).Entity;
                
                await _dbContext.SaveChangesAsync(cancellationToken);

                _logger.LogInformation("Entity added: @{TEntity}.", result);
            }
            catch(OperationCanceledException e)
            {
                _logger.LogWarning(e, "Added entity: @{TEntity}, canceled.", entity);
                throw;
            }
            catch (DbUpdateException e)
            {
                _logger.LogWarning(e, "Error add entity: @{TEntity}.", entity);

                try
                {
                    DbError dbError = _errorHandlerDb.GetInfoAboutError(e);

                    throw new RepositoryException("Error add entity.", e, dbError.Table, dbError.Fields, dbError.ErrorCode);
                }
                catch(ErrorHandlerDbException eDbError)
                {
                    _logger.LogError(eDbError, "Error Handling excetpion Db.");

                    throw new RepositoryException("Error add entity.", e);
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Unknow error add entity: @{TEntity}.", entity);
                throw new RepositoryException("Unknow error add entity.", e);
            }

            return result;
        }

        public Task<TEntity> Delete(VId id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
