namespace Antivenom.src.Infra;

internal interface IConfigValuesProvider
{
    string GetConfigValue(ConfigKeys key);
}
