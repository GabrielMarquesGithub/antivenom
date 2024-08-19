namespace Antivenom.src.Configs;

internal interface IConfiguration
{
    string GetConfigurationValue(ConfigurationKeys key);
}
