using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace AutoLotDAL.BulkImport {
    public class ProcessBulkImport {
        private SqlConnection connection = null;
        private readonly string connectionString; 
        public ProcessBulkImport(string connectionString) {
            this.connectionString = connectionString;
        }

        private void OpenConnection() {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private void CloseConnection() {
            if (connection.State != ConnectionState.Closed) {
                connection.Close();
            }
        }

        public void ExecuteBulkImport<T>(IEnumerable<T> records, string tableName) {
            OpenConnection();
            SqlBulkCopy sbc = new SqlBulkCopy(connection) {
                DestinationTableName = tableName
            };

            MyDataReader<T> reader = new MyDataReader<T>(records.ToList());
            try {
                sbc.WriteToServer(reader);
            } catch (Exception ex) {
                Console.WriteLine("Error: {0}", ex.Message);
            } finally {
                CloseConnection();
            }
        }
    }
}
