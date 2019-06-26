
// Connection Object

using System;
using System.Data;
using System.Data.Common;
using System.Configuration;


namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.ConnectionStrings[provider].ConnectionString;

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            
            DbConnection connection =  factory.CreateConnection();

            connection.ConnectionString = connectionString;
            connection.Open();

            DisplayInfoAboutConnection(connection);

            Console.ReadKey();
        }

        static void DisplayInfoAboutConnection(DbConnection connection) {

            Console.WriteLine("Database: {0}", connection.Database);
            Console.WriteLine("Data Source: {0}", connection.DataSource);
            Console.WriteLine("Timeout: {0}s", connection.ConnectionTimeout);
            Console.WriteLine("State: {0}", connection.State);
            Console.WriteLine("Server Version: {0}", connection.ServerVersion);
        }
    }
}