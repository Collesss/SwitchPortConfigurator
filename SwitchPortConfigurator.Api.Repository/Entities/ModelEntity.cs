namespace SwitchPortConfigurator.Api.Repository.Entities
{
    public class ModelEntity
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public int CountPorts { get; set; }

        public int ManufacturerId { get; set; }
    }
}
