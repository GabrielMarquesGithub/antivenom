using MySqlConnector;
using Antivenom.src.Configs;

namespace Antivenom.src.Data;

internal sealed class MySqlDatabaseConnection : IDatabaseConnection
{

    private readonly MySqlConnection _connection;

    public MySqlDatabaseConnection(IConfiguration configuration)
    {
        string connectionString = configuration.GetConfigurationValue(ConfigurationKeys.SQL_CONNECTION_STRING);
        _connection = new MySqlConnection(connectionString);
        _connection.Open();
    }


    public T ExecuteSQLQuery<T>(string query)
    {
        throw new NotImplementedException();
    }

    private MySqlCommand CreateCommand(string query)
    {
        MySqlCommand command = _connection.CreateCommand();
        command.CommandText = query;
        return command;
    }


}
