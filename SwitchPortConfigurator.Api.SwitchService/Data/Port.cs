namespace SwitchPortConfigurator.Api.SwitchService.Data
{
    public class Port
    {
        public string InterfaceName { get; set; }

        public PortState State { get; set; }

        public bool Access { get; set; }

        public IEnumerable<int> Vlans { get; set; } = new List<int>();
    }
}
