namespace SwitchPortConfigurator.Api.Dto.Location.Request
{
    public class CreateLocationRequestDto
    {
        public int Floor { get; set; }

        public int Cabinet { get; set; }

        public int AreaId { get; set; }
    }
}
