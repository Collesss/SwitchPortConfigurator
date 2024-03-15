using Renci.SshNet;
using SwitchPortConfigurator.Api.SwitchService.Data;
using SwitchPortConfigurator.Api.SwitchService.Exceptions;
using SwitchPortConfigurator.Api.SwitchService.Interfaces;
using System.Diagnostics;
using Switch = SwitchPortConfigurator.Api.SwitchService.Data.Switch;

namespace SwitchPortConfigurator.Api.SwitchService.Default.Implementations
{
    public class SwitchService : ISwitchService
    {
        


        

        public async Task<Switch> GetSwitch(string ip, CancellationToken cancellationToken = default)
        {
            using SshClient sshClient = new SshClient(ip, 10, "", "");

            await sshClient.ConnectAsync(cancellationToken);

            SshCommand command = sshClient.RunCommand("");

            Debug.WriteLine(command.Result);

            sshClient.Disconnect();

            throw new SwitchServiceException();
        }

        public Task<SwitchSummary> GetSwitchSummary(string ip, CancellationToken cancellationToken = default)
        {
            throw new SwitchServiceException();
        }

        public Task SetPortSetting(PortSetting portSetting, CancellationToken cancellationToken = default)
        {
            throw new SwitchServiceException();
        }

    }
}
