namespace SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Data
{
    public class DbError
    {
        public DbErrorCode ErrorCode { get; }

        public string Table { get; }

        public string Fields { get; }

        public DbError(DbErrorCode errorCode, string table, string fields) 
        {
            ErrorCode = errorCode;
            Table = table;
            Fields = fields;
        }
    }
}
