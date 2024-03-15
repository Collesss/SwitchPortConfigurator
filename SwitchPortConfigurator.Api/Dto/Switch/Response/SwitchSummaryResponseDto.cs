namespace SwitchPortConfigurator.Api.Dto.Switch.Response
{
    public class SwitchSummaryResponseDto
    {
        public int Id { get; set; }

        public string Ip { get; set; }

        public bool Online { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
