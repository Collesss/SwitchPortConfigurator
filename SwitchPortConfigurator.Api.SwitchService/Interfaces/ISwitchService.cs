using SwitchPortConfigurator.Api.SwitchService.Data;

namespace SwitchPortConfigurator.Api.SwitchService.Interfaces
{
    public interface ISwitchService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exceptions.SwitchServiceException"></exception>
        /// <returns></returns>
        Task<SwitchSummary> GetSwitchSummary(string ip, CancellationToken cancellationToken = default);

        Task<Switch> GetSwitch(string ip, CancellationToken cancellationToken = default);

        Task SetPortSetting(PortSetting portSetting, CancellationToken cancellationToken = default);
    }
}
