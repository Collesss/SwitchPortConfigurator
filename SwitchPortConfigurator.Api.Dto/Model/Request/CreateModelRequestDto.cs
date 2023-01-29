namespace SwitchPortConfigurator.Api.Dto.Model.Request
{
    public class CreateModelRequestDto
    {
        public string Model { get; set; }

        public int CountPorts { get; set; }

        public int ManufacturerId { get; set; }
    }
}
