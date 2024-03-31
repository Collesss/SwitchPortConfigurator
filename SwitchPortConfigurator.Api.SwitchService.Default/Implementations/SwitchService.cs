using Renci.SshNet;
using SwitchPortConfigurator.Api.Repository.Interfaces;
using SwitchPortConfigurator.Api.SwitchService.Data;
using SwitchPortConfigurator.Api.SwitchService.Exceptions;
using SwitchPortConfigurator.Api.SwitchService.Interfaces;
using System.Text;
using System.Text.RegularExpressions;
using Switch = SwitchPortConfigurator.Api.SwitchService.Data.Switch;

namespace SwitchPortConfigurator.Api.SwitchService.Default.Implementations
{
    public class SwitchService : ISwitchService
    {
        private ISwitchRepository _switchRepository;

        public SwitchService(ISwitchRepository switchRepository) 
        {
            _switchRepository = switchRepository;
        }


        public async Task<Switch> GetSwitch(int id, CancellationToken cancellationToken = default)
        {
            using SshClient sshClient = new SshClient("", "admin", "4321");

            await sshClient.ConnectAsync(cancellationToken);

            ShellStream shellStream = sshClient.CreateShellStream(string.Empty, 0, 0, 0, 0, 1024 * 1024);
            string except1 = "\r\r\n\0******************************************************************************\r\r\n* Copyright (c) 2004-2014 Hangzhou H3C Tech. Co., Ltd. All rights reserved.  *\r\r\n* Without the owner's prior written consent,                                 *\r\r\n* no decompiling or reverse-engineering shall be allowed.                    *\r\r\n******************************************************************************\r\r\n\r\r\n\0<TestSwitch1>";
            string except2 = "system-view\r\r\nSystem View: return to User View with Ctrl+Z.\r\r\n[TestSwitch1]";
            string except3 = "display interface GigabitEthernet";
            
            shellStream.Expect(except1);
            shellStream.WriteLine("system-view");
            shellStream.Expect(except2);
            shellStream.WriteLine("display interface GigabitEthernet");
            shellStream.Expect(except3);

            Regex regexExcept1 = new Regex("---- More ----", RegexOptions.Multiline);
            Regex regexExcept2 = new Regex(@"\[[^\[\]]+]", RegexOptions.Multiline);

            Regex commonExcept = new Regex(@"\[[^\[\]]+]|---- More ----", RegexOptions.Multiline);

            StringBuilder sbPortData = new StringBuilder();

            do
            {
                string result = shellStream.Expect(commonExcept);

                string res1 = commonExcept.Replace(result, string.Empty);

                sbPortData.Append(commonExcept.Replace(result, string.Empty));

                bool @continue = commonExcept.IsMatch(result);

                if (regexExcept1.IsMatch(result))
                    shellStream.WriteLine(" ");
                else
                    break;
            }
            while (true);


            string portData = sbPortData.ToString();

            //shellStream.Close();

            sshClient.Disconnect();

            throw new SwitchServiceException();
        }

        public Task<SwitchSummary> GetSwitchSummary(int id, CancellationToken cancellationToken = default)
        {
            throw new SwitchServiceException();
        }

        public Task SetPortSetting(PortSetting portSetting, CancellationToken cancellationToken = default)
        {
            throw new SwitchServiceException();
        }
    }
}
