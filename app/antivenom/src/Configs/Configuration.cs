using Antivenom.src.Infra;
using System.Text;

namespace Antivenom.src.Configs;

internal sealed class Configuration(IConfigValuesProvider configValuesProvider) : IConfiguration
{

    private readonly IConfigValuesProvider _configValuesProvider = configValuesProvider;

    public string GetConfigurationValue(ConfigurationKeys key)
    {
        return key switch
        {
            ConfigurationKeys.SQL_CONNECTION_STRING => GetConnectionString(),
            _ => throw new NotImplementedException("Essa chave de configuração não foi implementada."),
        };
    }

    private string GetConnectionString()
    {
        StringBuilder connectionString = new();

        Dictionary<string, ConfigKeys> connectionValues = new()
        {
            { "server", ConfigKeys.DB_HOST },
            { "port", ConfigKeys.DB_PORT },
            { "user", ConfigKeys.DB_USERNAME },
            { "password", ConfigKeys.DB_PASSWORD },
            { "database", ConfigKeys.DB_NAME }
        };

        foreach (string key in connectionValues.Keys)
        {
            connectionString.Append($"{key}={_configValuesProvider.GetConfigValue(connectionValues[key])};");
        }

        return connectionString.ToString();
    }
}

