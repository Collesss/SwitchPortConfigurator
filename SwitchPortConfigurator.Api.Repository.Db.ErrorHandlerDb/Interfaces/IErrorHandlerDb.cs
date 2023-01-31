using Microsoft.EntityFrameworkCore;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Data;

namespace SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Interfaces
{
    public interface IErrorHandlerDb
    {
        /// <summary>
        /// Get info about error DbUpdateException.
        /// </summary>
        /// <param name="dbUpdateException"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Argument null exception.</exception>
        /// <exception cref="Exceptions.ErrorHandlerDbException">Not handled exception.</exception>
        DbError GetInfoAboutError(DbUpdateException dbUpdateException);
    }
}
