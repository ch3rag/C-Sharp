// Simple Sql Reader

using System;
using System.Data.SqlClient;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {

            // create connection string
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder() {
                DataSource = "CHIRAG-DESK\\SQLEXPRESS",
                InitialCatalog = "AutoLot",
                IntegratedSecurity = true
            };

            // create a connection with the string
            SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

            // open the connection
            connection.Open();

            // create a command object
            SqlCommand command = new SqlCommand("Select * From Inventory", connection);

            // get data reader from command object
            using (SqlDataReader reader = command.ExecuteReader()) {
                while (reader.Read()) {
                    Console.WriteLine("CarID: {0}; PetName: {1}; Make: {2}; Color: {3}", reader["CarId"], reader["PetName"], reader["Make"], reader["Color"]);
                }
            }

            Console.ReadKey();
        }
    }
}