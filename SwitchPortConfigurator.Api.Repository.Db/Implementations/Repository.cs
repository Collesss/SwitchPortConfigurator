using EntityFramework.Exceptions.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwitchPortConfigurator.Api.Repository.Exceptions;
using SwitchPortConfigurator.Api.Repository.Interfaces;
using System.Text.RegularExpressions;

namespace SwitchPortConfigurator.Api.Repository.Db.Implementations
{
    public abstract class Repository<TEntity, VId, EDbContext> : IRepository<TEntity, VId>
        where TEntity : class
        where EDbContext : DbContext
    {
        private readonly ILogger<Repository<TEntity, VId, EDbContext>> _logger;
        protected readonly EDbContext _dbContext;

        public Repository(ILogger<Repository<TEntity, VId, EDbContext>> logger, EDbContext dbContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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

                if(e.InnerException is SqliteException sqliteEx)
                {
                    throw (errorCode: sqliteEx.SqliteErrorCode, extendedErrorCode: sqliteEx.SqliteExtendedErrorCode) switch
                        {
                            (19, 2067) error => new RepositoryException(sqliteEx.Message, e, 
                                Regex.Match(sqliteEx.Message, @"(?<table>\w+)\.(?<field>\w+)").Groups["table"].Value,
                                Regex.Match(sqliteEx.Message, @"(?<table>\w+)\.(?<field>\w+)").Groups["field"].Value,
                                error.errorCode*error.extendedErrorCode),
                            _ => new RepositoryException("Unexcepted error added.", e)
                        };
                }

                throw new RepositoryException("Error add entity.", e);
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
