namespace SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Data
{
    public class DbError
    {
        public int ErrorCode { get; }

        public string Table { get; }

        public string Fields { get; }

        public DbError(int errorCode, string table, string fields) 
        {
            ErrorCode = errorCode;
            Table = table;
            Fields = fields;
        }
    }
}
