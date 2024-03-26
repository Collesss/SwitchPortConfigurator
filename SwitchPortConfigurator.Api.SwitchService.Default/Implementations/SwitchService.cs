using Renci.SshNet;
using SwitchPortConfigurator.Api.SwitchService.Data;
using SwitchPortConfigurator.Api.SwitchService.Exceptions;
using SwitchPortConfigurator.Api.SwitchService.Interfaces;
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
            string except1 = "\r\r\n\0******************************************************************************\r\r\n* Copyright (c) 2004-2014 Hangzhou H3C Tech. Co., Ltd. All rights reserved.  *\r\r\n* Without the owner's prior written consent,                                 *\r\r\n* no decompiling or reverse-engineering shall be allowed.                    *\r\r\n******************************************************************************\r\r\n\r\r\n\0<TestSwitch1>";
            string except1Result = shellStream.Expect(except1);

            
            shellStream.WriteLine("system-view");
            string except2 = "system-view\r\r\nSystem View: return to User View with Ctrl+Z.\r\r\n[TestSwitch1]";
            string except2Result = shellStream.Expect(except2);

            
            shellStream.WriteLine("display interface GigabitEthernet");
            shellStream.Expect("display interface GigabitEthernet");

            string except3 = "---- More ----";
            string except4 = "[TestSwitch1]";




            //shellStream.Close();

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


        private async Task<string> ReadFull(ShellStream shellStream)
        {
            StringBuilder sb = new StringBuilder();
            
            while(shellStream.DataAvailable)
            {
                byte[] buffer = new byte[1024];

                int len = await shellStream.ReadAsync(buffer, 0, buffer.Length);

                sb.Append(Encoding.ASCII.GetString(buffer, 0, len));
            }

            return sb.ToString();
        }
    }
}
