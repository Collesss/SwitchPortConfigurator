namespace SwitchPortConfigurator.Api.Dto.Model.Response
{
    public class ModelResponseDto
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public int CountPorts { get; set; }

        public int ManufacturerId { get; set; }
    }
}
