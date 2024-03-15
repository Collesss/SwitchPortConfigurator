using SwitchPortConfigurator.Api.SwitchService.Data;
using SwitchPortConfigurator.Api.SwitchService.Interfaces;

namespace SwitchPortConfigurator.Api.SwitchService.Default.Implementations
{
    public class SwitchService : ISwitchService
    {
        public Task<Switch> GetSwitch(string ip, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<SwitchSummary> GetSwitchSummary(string ip, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task SetPortSetting(PortSetting portSetting, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
