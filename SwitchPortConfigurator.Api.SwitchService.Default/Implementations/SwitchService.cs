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


            byte[] readerBuffer = new byte[1024];

            Stream reader = new MemoryStream(readerBuffer);

            byte[] writerBuffer = new byte[1024];

            Stream writer = new MemoryStream(writerBuffer);

            Shell shell = sshClient.CreateShell(writer, reader, reader);

            shell.Start();

            byte[] command = Encoding.ASCII.GetBytes("system-view\r\n");

            await writer.WriteAsync(command, 0, command.Length, cancellationToken);

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
