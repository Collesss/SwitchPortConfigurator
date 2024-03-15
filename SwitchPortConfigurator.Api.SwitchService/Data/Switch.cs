namespace SwitchPortConfigurator.Api.SwitchService.Data
{
    public class Switch : SwitchSummary
    {
        IEnumerable<Port> Ports { get; set; } = new List<Port>();

        IEnumerable<Vlan> Vlans { get; set; } = new List<Vlan>();
    }
}
