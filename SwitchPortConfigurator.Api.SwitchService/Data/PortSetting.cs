namespace SwitchPortConfigurator.Api.SwitchService.Data
{
    public class PortSetting
    {
        public int SwitchId { get; set; }

        public string InterfaceName { get; set; }

        public string Description { get; set; }

        public bool Enable { get; set; }

        public bool Access {  get; set; }

        public IEnumerable<int> Vlans { get; set; }
    }
}
