namespace SwitchPortConfigurator.Api.Dto.Port.Request
{
    public class PortTrunkRequestDto
    {
        public int SwitchId { get; set; }

        public string InterfaceName { get; set; }

        public IEnumerable<int> Vlans { get; set; }
    }
}
