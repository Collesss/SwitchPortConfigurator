using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Data;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Exceptions;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Interfaces;
using System.Text.RegularExpressions;

namespace SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.SqlErrorHandler.Implementations
{
    public class ErrorHandlerDb : IErrorHandlerDb
    {
        private static readonly Dictionary<(int errorCode, int extendedErrorCode), (DbErrorCode dbErrorCode, Regex regex)> Errors = new()
        {
            [(19, 2067)] = (DbErrorCode.CONSTRAINT_UNIQUE, new Regex(@"(?<table>\w+)\.(?<field>\w+)")),
            [(19, 275)] = (DbErrorCode.CONSTRAINT_CHECK, new Regex(@"(?<table>\w+)\.(?<field>\w+)")),
            [(19, 1555)] = (DbErrorCode.CONSTRAINT_PRIMARYKEY, new Regex(@"(?<table>\w+)\.(?<field>\w+)")),
            [(19, 1299)] = (DbErrorCode.CONSTRAINT_NOTNULL, new Regex(@"(?<table>\w+)\.(?<field>\w+)")),
            [(19, 787)] = (DbErrorCode.CONSTRAINT_FOREIGNKEY, new Regex(@"(?<table>\w+)\.(?<field>\w+)"))
        };

        public DbError GetInfoAboutError(DbUpdateException dbUpdateException)
        {
            ArgumentNullException.ThrowIfNull(dbUpdateException, nameof(dbUpdateException));

            if (dbUpdateException.InnerException is not SqliteException sqliteException)
                throw new ErrorHandlerDbException("Not supported exception.");

            if(!Errors.TryGetValue((sqliteException.SqliteErrorCode, sqliteException.SqliteExtendedErrorCode), out var val))
                throw new ErrorHandlerDbException("Not supported Error Code.");

            var (dbErrorCode, regex) = val;
            var match = regex.Match(sqliteException.Message);

            return new DbError(dbErrorCode, match.Groups["table"].Value, match.Groups["field"].Value);
        }
    }
}
