using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace AutoLot.BulkOperations {
    public class ProcessBulkImport {
        private SqlConnection connection;
        private string connectionString;

        public ProcessBulkImport(string connectionString) {
            this.connectionString = connectionString;
            connection = new SqlConnection(connectionString);
        }

        private void OpenConnection() {
            connection.Open();
        }

        private void CloseConnection() {
            if (connection.State != ConnectionState.Closed) {
                connection.Close();
            }
        }

        public bool Execute<T> (IEnumerable<T> records, string tableName) {
            
            OpenConnection();
            
            SqlBulkCopy sbc = new SqlBulkCopy(connection) {
                DestinationTableName  = tableName
            };

            GenericDataReader<T> reader = new GenericDataReader<T>(records.ToList());
            try {
                sbc.WriteToServer(reader);
            } catch (Exception ex) {
                return false;
            }
            
            CloseConnection();
            return true;
        }
    }
}
