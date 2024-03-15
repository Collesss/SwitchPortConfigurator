namespace SwitchPortConfigurator.Api.Dto.Switch.Response
{
    public class SwitchResponseDto : SwitchSummaryResponseDto
    {
        public IEnumerable<PortResponseDto> Ports { get; set; } = new List<PortResponseDto>();

        public IEnumerable<VlanResponseDto> Vlans { get; set; } = new List<VlanResponseDto>();
    }
}
