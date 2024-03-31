namespace SwitchPortConfigurator.Api.Repository.Entities
{
    public class PortsModel : BaseEntity<int>
    {
        public int PortTypeId { get; set; }

        public PortTypeEntity PortType { get; set; }

        public string Number { get; set; }

        public int ModelId { get; set; }

        public ModelEntity Model { get; set; }
    }
}
