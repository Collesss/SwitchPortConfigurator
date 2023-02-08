namespace SwitchPortConfigurator.Api.Dto.Common.Response
{
    public class BadRequestResponse
    {
        public string Message { get; set; }

        public string Code { get; set; }

        public IEnumerable<BadRequestError> badRequestErrors { get; set; }
    }
}
