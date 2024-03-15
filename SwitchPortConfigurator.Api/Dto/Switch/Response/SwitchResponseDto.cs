namespace SwitchPortConfigurator.Api.Dto.Switch.Response
{
    public class SwitchResponseDto : SwitchSummaryResponseDto
    {
        public IEnumerable<PortResponseDto> Ports { get; set; }

        public IEnumerable<VlanResponseDto> Vlans { get; set; }
    }
}
