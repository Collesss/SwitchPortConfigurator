namespace SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Exceptions
{
    public class ErrorHandlerDbException : Exception
    {
        public ErrorHandlerDbException() { }

        public ErrorHandlerDbException(string message) : base(message) { }

        public ErrorHandlerDbException(string message, Exception innerException) : base(message, innerException) { }

    }
}
