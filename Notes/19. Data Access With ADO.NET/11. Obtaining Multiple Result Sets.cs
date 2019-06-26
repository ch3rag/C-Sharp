// Obtaining Multiple Result Sets

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

            DbConnection connection = factory.CreateConnection();

            connection.ConnectionString = connectionString;
            connection.Open();

            DbCommand command = factory.CreateCommand();

            command.Connection = connection;
            command.CommandText = "Select * From Inventory; Select * From Customers";

            using (DbDataReader reader = command.ExecuteReader()) {

                do {
                    while (reader.Read()) {
                        Console.WriteLine("*** Record ***");
                        for (int i = 0; i < reader.FieldCount; i++) {
                            Console.WriteLine("{0}: {1}", reader.GetName(i), reader.GetValue(i));
                        }
                        Console.WriteLine();
                    }
                } while (reader.NextResult());
            }

            Console.ReadKey();
        }
    }
}