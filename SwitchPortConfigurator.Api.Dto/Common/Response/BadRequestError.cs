namespace SwitchPortConfigurator.Api.Dto.Common.Response
{
    public class BadRequestError
    {
        public string Field { get; set; }

        public string ErrorCode { get; set; }

        public string Message { get; set; }
    }
}
