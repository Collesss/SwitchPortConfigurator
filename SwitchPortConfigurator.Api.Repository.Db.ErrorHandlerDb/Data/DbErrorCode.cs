namespace SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Data
{
    public enum DbErrorCode
    {
        CONSTRAINT,
        CONSTRAINT_PRIMARYKEY,
        CONSTRAINT_UNIQUE,
        CONSTRAINT_NOTNULL,
        CONSTRAINT_FOREIGNKEY,
        CONSTRAINT_CHECK
    }
}
