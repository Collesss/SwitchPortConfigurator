using SwitchPortConfigurator.Api.Repository.Exceptions;

namespace SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Data
{
    public class DbError
    {
        public RepositoryErrorCode ErrorCode { get; }

        public string Table { get; }

        public string Fields { get; }

        public DbError(RepositoryErrorCode errorCode, string table, string fields) 
        {
            ErrorCode = errorCode;
            Table = table;
            Fields = fields;
        }
    }
}
