using Antivenom.src.Configs;
using Antivenom.src.Infra;
using MySqlConnector;

string dotEnvFilePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "configs", ".env");
IConfigValuesProvider configValuesProvider = new DotEnvConfigValuesProvider(dotEnvFilePath);
IConfiguration configuration = new Configuration(configValuesProvider);
string connectionString = configuration.GetConfigurationValue(ConfigurationKeys.SQL_CONNECTION_STRING);
Console.WriteLine("Connection string: " + connectionString);
using MySqlConnection connection = new(connectionString);
try
{
    connection.Open();
    Console.WriteLine("Connected to MySQL database!");

    MySqlCommand command = connection.CreateCommand();
    command.CommandText = "SELECT * FROM city";
    using MySqlDataReader reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine(reader["name"]);
    }

    connection.Close();
    Console.WriteLine("Disconnected from MySQL database!");
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}

