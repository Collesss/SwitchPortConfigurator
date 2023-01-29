namespace SwitchPortConfigurator.Api.Dto.Switch.Response
{
    public class SwitchResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IPAddress { get; set; }

        public string MacAddress { get; set; }

        public int ModelId { get; set; }

        public int LocationId { get; set; }
    }
}
