namespace SwitchPortConfigurator.Api.Repository.Exceptions
{
    public class RepositoryException : Exception
    {
        public string Table { get; }

        public string Field { get; }

        public RepositoryErrorCode ErrorCode { get; }

        public RepositoryException(string message) : base(message) { }

        public RepositoryException(string message, string table, string field, RepositoryErrorCode errorCode) : base(message)
        {
            Table = table;
            Field = field;
            ErrorCode = errorCode;
        }

        public RepositoryException(string message, Exception innerException) : base(message, innerException) { }

        public RepositoryException(string message, Exception innerException, string table, string field, RepositoryErrorCode errorCode) : base(message, innerException) 
        {
            Table = table;
            Field = field;
            ErrorCode = errorCode;
        }
    }
}
