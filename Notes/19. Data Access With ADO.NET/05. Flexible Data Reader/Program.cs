using System;
using System.Data;
using System.Data.Common;
using System.Configuration;


namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            // get data provider from config
            string dataProvider = ConfigurationManager.AppSettings.Get("provider");

            // get connection string
            string connectionString = ConfigurationManager.AppSettings.Get("connectionString");

            // get factory provider for the data provider
            DbProviderFactory factory = null;
            try {
                 factory = DbProviderFactories.GetFactory(dataProvider);
            } catch (ArgumentException ex) {
                DisplayError(ex.Message);
                return;
            }

            using (DbConnection connection = factory.CreateConnection()) {
                if (connection == null) {
                    DisplayError("Failed To Create A Connection.");
                    return;
                }

                Console.WriteLine("Connection Object: {0}", connection.GetType().Name);

                connection.ConnectionString = connectionString;

                try {
                    connection.Open();
                } catch (Exception ex) {
                    DisplayError("Failed To Open Connection!");
                }

                // create a command object
                DbCommand command = factory.CreateCommand();

                if (command == null) {
                    DisplayError("Failed To Create Command Object!");
                    return;
                }

                Console.WriteLine("Command Object: {0}", command.GetType().Name);

                // set connection for command object
                command.Connection = connection;
                
                // specify query
                command.CommandText = "SELECT * FROM Inventory";

                using (DbDataReader dataReader = command.ExecuteReader()) {
                    Console.WriteLine("Reader Object: {0}", dataReader.GetType().Name);
                    Console.WriteLine("Inventory Information: ");
                    while (dataReader.Read()) {
                        Console.WriteLine("Car ID: {0}; Make: {1}; Color: {2}; PetName: {3}", dataReader["CarId"], dataReader["Make"], dataReader["Color"], dataReader["PetName"]);
                    }
                }

            }

    
            Console.ReadKey();
        }


        
        public static void DisplayError(string message) {
            ConsoleColor current = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: {0}", message);
            Console.ForegroundColor = current;
        }
    }
}