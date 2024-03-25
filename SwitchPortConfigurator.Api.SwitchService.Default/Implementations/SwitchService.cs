using Renci.SshNet;
using SwitchPortConfigurator.Api.SwitchService.Data;
using SwitchPortConfigurator.Api.SwitchService.Exceptions;
using SwitchPortConfigurator.Api.SwitchService.Interfaces;
using System.Diagnostics;
using System.Text;
using Switch = SwitchPortConfigurator.Api.SwitchService.Data.Switch;

namespace SwitchPortConfigurator.Api.SwitchService.Default.Implementations
{
    public class SwitchService : ISwitchService
    {
        

        public async Task<Switch> GetSwitch(string ip, CancellationToken cancellationToken = default)
        {
            using SshClient sshClient = new SshClient(ip, "admin", "4321");

            await sshClient.ConnectAsync(cancellationToken);

            ShellStream shellStream = sshClient.CreateShellStream(string.Empty, 0, 0, 0, 0, 1024 * 1024);

            shellStream.WriteLine("system-view");
            shellStream.WriteLine("display interface GigabitEthernet");

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
