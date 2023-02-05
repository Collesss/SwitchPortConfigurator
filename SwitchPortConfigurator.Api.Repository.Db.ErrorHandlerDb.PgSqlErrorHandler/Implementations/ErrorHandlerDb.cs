using Microsoft.EntityFrameworkCore;
using Npgsql;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Data;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Exceptions;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Interfaces;
using System.Text.RegularExpressions;

namespace SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.PgSqlErrorHandler.Implementations
{
    public class ErrorHandlerDb : IErrorHandlerDb
    {
        private static readonly Dictionary<string, (DbErrorCode dbErrorCode, Regex regex)> Errors = new()
        {
            ["23505"] = (DbErrorCode.CONSTRAINT_UNIQUE, new Regex(@"^(?<type>[^_]+)_(?<table>[^_]+)_(?<field>[^_]+)$")),
            ["23514"] = (DbErrorCode.CONSTRAINT_CHECK, new Regex(@"^(?<type>[^_]+)_(?<table>[^_]+)_(?<field>[^_]+)$")),
            ["23502"] = (DbErrorCode.CONSTRAINT_NOTNULL, new Regex(@"^(?<type>[^_]+)_(?<table>[^_]+)_(?<field>[^_]+)$")),
            ["23503"] = (DbErrorCode.CONSTRAINT_FOREIGNKEY, new Regex(@"^(?<type>[^_]+)_(?<table>[^_]+)_(?<field>[^_]+)$"))
        };

        public DbError GetInfoAboutError(DbUpdateException dbUpdateException)
        {
            ArgumentNullException.ThrowIfNull(dbUpdateException, nameof(dbUpdateException));

            if(dbUpdateException.InnerException is not PostgresException postgresException)
                throw new ErrorHandlerDbException("Not supported exception.");
            
            if (!Errors.TryGetValue(postgresException.SqlState, out var val))
                throw new ErrorHandlerDbException("Not supported Error Code.");

            var (dbErrorCode, regex) = val;

            try
            {
                var match = regex.Match(postgresException.ConstraintName);
                return new DbError(dbErrorCode, match.Groups["table"].Value, match.Groups["field"].Value);
            }
            catch(Exception ex) 
            {
                throw new ErrorHandlerDbException("Error handling error.", ex);
            }
        }
    }
}
