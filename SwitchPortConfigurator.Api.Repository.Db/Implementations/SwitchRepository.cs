using Microsoft.EntityFrameworkCore;
using SwitchPortConfigurator.Api.Repository.Entities;
using SwitchPortConfigurator.Api.Repository.Interfaces;

namespace SwitchPortConfigurator.Api.Repository.Db.Implementations
{
    public class SwitchRepository : ISwitchRepository
    {
        private readonly RepositoryDbContext _repositoryDbContext;

        public SwitchRepository(RepositoryDbContext repositoryDbContext) 
        {
            _repositoryDbContext = repositoryDbContext ?? throw new ArgumentNullException(nameof(repositoryDbContext));
        }

        public async Task<int> Add(SwitchEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _repositoryDbContext.AddAsync(entity, cancellationToken);

                await _repositoryDbContext.SaveChangesAsync(cancellationToken);

                return result.Entity.Id;
            }
            catch(DbUpdateException)
            {
                throw;
            }
        }

        public async Task Delete(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = _repositoryDbContext.Switches.Remove(new SwitchEntity { Id = id });

                await _repositoryDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<IEnumerable<SwitchEntity>> GetAll(CancellationToken cancellationToken = default) =>
            await _repositoryDbContext.Switches.ToListAsync(cancellationToken);

        public async Task<SwitchEntity> GetById(int id, CancellationToken cancellationToken = default) =>
            await _repositoryDbContext.Switches.FindAsync(new object[] { id }, cancellationToken);
    }
}
