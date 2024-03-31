namespace SwitchPortConfigurator.Api.Repository.Entities
{
    public class SwitchEntity : BaseEntity<int>
    {
        public string Ip { get; set; }

        public string Location { get; set; }

        public int ModelId { get; set; }

        public ModelEntity Model { get; set; }
    }
}
