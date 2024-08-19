namespace Antivenom.src.Data;

internal interface IDatabaseConnection
{
    T ExecuteSQLQuery<T>(string query);
}
