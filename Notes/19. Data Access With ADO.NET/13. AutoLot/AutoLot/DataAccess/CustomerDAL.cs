using System;
using System.Data;
using System.Data.SqlClient;

namespace AutoLot.AutoLotDAL {
    
    public class CustomerDAL {

        private readonly string connectionString;
        private SqlConnection connection;

        public CustomerDAL(string connectionString) {
            this.connectionString = connectionString;
            this.connection = new SqlConnection(connectionString);
        }

        private void OpenConnection() {
            connection.Open();
        }

        private void CloseConnection() {
            if (connection.State != ConnectionState.Closed) {
                connection.Close();
            }
        }

        public bool ProcessCreditRisk(int custId, bool throwEx = false) {
            string firstName, lastName;
            OpenConnection();
            string cmd = "SELECT * FROM Customers WHERE CustId = @CustId";
            using (SqlCommand command = new SqlCommand(cmd, connection)) {
                command.Parameters.Add(new SqlParameter() {
                    ParameterName = "@CustId",
                    Value = custId,
                    SqlDbType = SqlDbType.Int
                });
                using (SqlDataReader reader = command.ExecuteReader()) {
                    reader.Read();
                    if (reader.HasRows) {
                        firstName = (string)reader["FirstName"];
                        lastName = (string)reader["LastName"];
                    } else {
                        return false;
                    }
                }
            }

            SqlTransaction transaction = null;

            string cmdDelete = "DELETE FROM Customers WHERE CustId = @CustId";
            string cmdInsert = "INSERT INTO CreditRisks ( FirstName, LastName ) Values ( @FirstName, @LastName )";

            SqlCommand commandDelete = new SqlCommand(cmdDelete, connection);
            SqlCommand commandInsert = new SqlCommand(cmdInsert, connection);

            commandDelete.Parameters.Add(new SqlParameter() {
                ParameterName = "@CustId",
                Value = custId,
                SqlDbType = SqlDbType.Int
            });

            commandInsert.Parameters.Add(new SqlParameter() {
                ParameterName = "@FirstName",
                Value = firstName,
                SqlDbType = SqlDbType.Char,
                Size = firstName.Length
            });

            commandInsert.Parameters.Add(new SqlParameter() {
                ParameterName = "@LastName",
                Value =  lastName,
                SqlDbType = SqlDbType.Char,
                Size = lastName.Length
            });

            
            try {

                transaction = connection.BeginTransaction();

                commandDelete.Transaction = transaction;
                commandInsert.Transaction = transaction;

                commandDelete.ExecuteNonQuery();
                commandInsert.ExecuteNonQuery();

                if (throwEx) {
                    throw new Exception("Transaction Failed!");
                }

                transaction.Commit();
                Console.WriteLine("Transaction Success!");

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                if (transaction != null) {
                    transaction.Rollback();
                }
                return false;
            }

            CloseConnection();
            return true;
        }
    }
}
