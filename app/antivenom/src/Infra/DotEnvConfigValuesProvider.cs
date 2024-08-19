namespace Antivenom.src.Infra;

internal sealed class DotEnvConfigValuesProvider : IConfigValuesProvider
{
    public DotEnvConfigValuesProvider(string dotEnvFilePath)
    {
        ValidateFilePath(dotEnvFilePath);
        LoadDotEnvFile(dotEnvFilePath);
    }

    private static void ValidateFilePath(string dotEnvFilePath)
    {
        if (string.IsNullOrWhiteSpace(dotEnvFilePath))
        {
            throw new ArgumentException("O caminho para o arquivo '.env' não pode ser nulo ou vazio", nameof(dotEnvFilePath));
        }

        if (!File.Exists(dotEnvFilePath))
        {
            throw new FileNotFoundException($"O arquivo '.env' não foi encontrado no caminho '{dotEnvFilePath}'");
        }
    }

    private static void LoadDotEnvFile(string dotEnvFilePath)
    {
        foreach (string line in File.ReadAllLines(dotEnvFilePath))
        {
            LoadValidLines(line);
        }
    }

    private static void LoadValidLines(string line)
    {
        if (string.IsNullOrWhiteSpace(line) || line.StartsWith('#'))
        {
            return;
        }

        string lineWithoutComments = RemoveComments(line);

        string[] parts = lineWithoutComments.Split('=');
        if (parts.Length == 2)
        {
            string key = parts[0].Trim();
            string value = parts[1].Trim();

            Environment.SetEnvironmentVariable(key, value);
        }

    }

    private static string RemoveComments(string line)
    {
        if (line.Contains('#'))
        {
            string[] parts = line.Split('#');
            return parts[0];
        }

        return line;
    }

    private static string GetEnvironmentVariable(string key)
    {
        string? value = Environment.GetEnvironmentVariable(key);
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"A variável de ambiente '{key}' não foi encontrada");
        }

        return value;
    }

    public string GetConfigValue(ConfigKeys key)
    {
        string keyString = key.ToString();
        return GetEnvironmentVariable(keyString);
    }
}
