namespace SwitchPortConfigurator.Api.Dto.Port.Request
{
    public class PortAccessRequestDto
    {
        public int SwitchId { get; set; }

        public string InterfaceName { get; set; }

        public int Vlan {  get; set; }
    }
}
