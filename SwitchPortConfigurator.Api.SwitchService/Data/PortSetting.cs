namespace SwitchPortConfigurator.Api.SwitchService.Data
{
    public class PortSetting
    {
        public string SwitchIp { get; set; }

        public string InterfaceName { get; set; }

        public bool Access {  get; set; }

        public IEnumerable<int> Vlans { get; set; }
    }
}
