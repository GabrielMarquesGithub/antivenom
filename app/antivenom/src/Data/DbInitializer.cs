using Antivenom.src.Data;

internal sealed class DbInitializer
{


    public static void Initialize(IDatabaseConnection databaseConnection)
    {
        CreateEntities(databaseConnection);
    }

    private static void CreateEntities(IDatabaseConnection databaseConnection)
    {
        string createTableQuery =
        @"DROP TABLE IF EXISTS cities;
        CREATE TABLE cities (
            id INT AUTO_INCREMENT PRIMARY KEY, 
            name VARCHAR(255) NOT NULL,       
            country VARCHAR(255) NOT NULL,     
            state VARCHAR(255), -- Alguns países não possuem estados
            population INT UNSIGNED,       
            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, 
            updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP 
        ) ENGINE=InnoDB;";

        databaseConnection.ExecuteSQLQuery<int>(createTableQuery);
    }
}