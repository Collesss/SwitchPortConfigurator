using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Data;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Exceptions;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Interfaces;

namespace SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.SqlErrorHandler.Implementations
{
    public class ErrorHandlerDb : IErrorHandlerDb
    {
        public DbError GetInfoAboutError(DbUpdateException dbUpdateException)
        {
            ArgumentNullException.ThrowIfNull(dbUpdateException, nameof(dbUpdateException));

            if (dbUpdateException.InnerException is not SqliteException sqliteException)
                throw new ErrorHandlerDbException("Not supported exception.");

            return (sqliteException.SqliteErrorCode, sqliteException.SqliteExtendedErrorCode) switch
            {
                (19, 2067) => new DbError(0, "", ""),
                _ => throw new ErrorHandlerDbException("Not supported error code.")
            };
        }
    }
}
