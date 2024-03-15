using SwitchPortConfigurator.Api.Repository.Entities;

namespace SwitchPortConfigurator.Api.Repository.Interfaces
{
    public interface ISwitchRepository
    {
        public Task<IEnumerable<SwitchEntity>> GetAll(CancellationToken cancellationToken = default);

        public Task<SwitchEntity> GetById(int id, CancellationToken cancellationToken = default);

        public Task<int> Add(SwitchEntity entity, CancellationToken cancellationToken = default);

        public Task Delete(int id, CancellationToken cancellationToken = default);
    }
}
