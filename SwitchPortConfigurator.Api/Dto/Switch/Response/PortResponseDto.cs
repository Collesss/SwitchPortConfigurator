namespace SwitchPortConfigurator.Api.Dto.Switch.Response
{
    public class PortResponseDto
    {
        public string InterfaceName {  get; set; }

        public PortStateReponseDto State { get; set; }

        public bool Access { get; set; }

        public IEnumerable<int> Vlans { get; set; } = new List<int>();
    }
}
