using Microsoft.EntityFrameworkCore;
using Npgsql;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Data;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Exceptions;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Interfaces;
using SwitchPortConfigurator.Api.Repository.Exceptions;
using System.Text.RegularExpressions;

namespace SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.PgSqlErrorHandler.Implementations
{
    public class ErrorHandlerDb : IErrorHandlerDb
    {
        private static readonly Dictionary<string, RepositoryErrorCode> Errors = new()
        {
            ["23505"] = RepositoryErrorCode.CONSTRAINT_UNIQUE,
            ["23514"] = RepositoryErrorCode.CONSTRAINT_CHECK,
            ["23502"] = RepositoryErrorCode.CONSTRAINT_NOTNULL,
            ["23503"] = RepositoryErrorCode.CONSTRAINT_FOREIGNKEY
        };

        public DbError GetInfoAboutError(DbUpdateException dbUpdateException)
        {
            ArgumentNullException.ThrowIfNull(dbUpdateException, nameof(dbUpdateException));

            if(dbUpdateException.InnerException is not PostgresException postgresException)
                throw new ErrorHandlerDbException("Not supported exception.");
            
            if (!Errors.TryGetValue(postgresException.SqlState, out var errorCode))
                throw new ErrorHandlerDbException("Not supported Error Code.");

            try
            {
                Regex regex = new(@"^(?<type>[^_]+)_(?<table>[^_]+)_(?<field>[^_]+)$");
                Match match = regex.Match(postgresException.ConstraintName);
                return new DbError(errorCode, match.Groups["table"].Value, match.Groups["field"].Value);
            }
            catch(Exception ex) 
            {
                throw new ErrorHandlerDbException("Error handling error.", ex);
            }
        }
    }
}
