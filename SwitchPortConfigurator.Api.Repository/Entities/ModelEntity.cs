namespace SwitchPortConfigurator.Api.Repository.Entities
{
    public class ModelEntity : BaseEntity<int>
    {
        public string Name { get; set; }

        public IEnumerable<PortsModel> Ports { get; set; }
    }
}
