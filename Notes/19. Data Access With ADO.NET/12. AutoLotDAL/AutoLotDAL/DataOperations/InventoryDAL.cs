using System;
using System.Data.SqlClient;
using System.Data;
using AutoLotDAL.Models;
using System.Collections.Generic;

namespace AutoLotDAL.DataOperations {
    
    public class InventoryDAL {
        
        private readonly string connectionString;
        private SqlConnection connection;

        public InventoryDAL(string connectionString) {
            this.connectionString = connectionString;
        }

        private void OpenConnection() {
            connection = new SqlConnection(this.connectionString);
            connection.Open();
        }

        private void CloseConnection() {
            if (connection.State != ConnectionState.Closed) {
                connection.Close();
            }
        }

        public List<Car> GetAllInventory() {
            OpenConnection();
            List<Car> inventory = new List<Car>();
            string cmd = "SELECT * FROM INVENTORY";
            using (SqlCommand command = new SqlCommand(cmd, this.connection)) {
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        inventory.Add(new Car {
                            CarId = (int)reader["CarId"],
                            Make = (string)reader["Make"],
                            PetName = (string)reader["PetName"],
                            Color = (string)reader["Color"]
                        });
                    }
                }
            }
            CloseConnection();
            return inventory;
        }

        public Car GetCar(int id) {
            OpenConnection();
            Car car = null;
            string cmd = "SELECT * FROM INVENTORY WHERE CarId = @CarId;";
            using (SqlCommand command = new SqlCommand(cmd, this.connection)) {

                command.Parameters.Add(new SqlParameter("@CarId", id));
 
                using (SqlDataReader reader = command.ExecuteReader()) {
                    reader.Read();
                    car = new Car() {
                        CarId = (int)reader["CarId"],
                        Make = (string)reader["Make"],
                        PetName = (string)reader["PetName"],
                        Color = (string)reader["Color"]
                    };
                }
            }
            CloseConnection();
            return car;
        }

        public void InsertAuto(string PetName, string Make, string Color) {
            OpenConnection();
            string cmd = "Insert Into Inventory (PetName, Make, Color) Values ( @PetName, @Make, @Color );";
            using(SqlCommand command = new SqlCommand(cmd, this.connection)) {
                // using SqlParameters
                command.Parameters.Add(CreateParameter("@PetName", PetName, SqlDbType.Char, PetName.Length));
                command.Parameters.Add(CreateParameter("@Make", Make, SqlDbType.Char, Make.Length));
                command.Parameters.Add(CreateParameter("@Color", Color, SqlDbType.Char, Color.Length));
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public void InsertAuto(Car car) {
            InsertAuto(car.PetName, car.Make, car.Color);
        }

        public void DeletCar(int id) {
            OpenConnection();
            string cmd = "Delete From Inventory Where CarId = @CarId;";
            using (SqlCommand command = new SqlCommand(cmd, this.connection)) {
                command.Parameters.Add(new SqlParameter("@CarId", id));
                try {
                    command.ExecuteNonQuery();
                } catch (SqlException ex) {
                    Exception err = new Exception("Sorry! That car is on order!", ex);
                    throw err;
                } finally {
                    CloseConnection();
                }
            }
        }

        public void UpdateCarPetName(int id, string newPetName) {
            OpenConnection();
            string cmd = "Update Inventory Set PetName = @PetName Where CarId = @CarId;";
            using (SqlCommand command = new SqlCommand(cmd, this.connection)) {
                command.Parameters.Add(new SqlParameter("@CarId", id));
                command.Parameters.Add(CreateParameter("@PetName", newPetName, SqlDbType.Char,  newPetName.Length));
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public string LookUpPetName(int id) {
            OpenConnection();
            string petName = String.Empty;
            using (SqlCommand command = new SqlCommand("GetPetName", this.connection)) {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter() {
                    ParameterName = "@CarId", 
                    SqlDbType = SqlDbType.Int,
                    Value = id,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter() {
                    ParameterName = "@PetName",
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                    Direction = ParameterDirection.Output
                });

                command.ExecuteNonQuery();
                
                petName = (string)command.Parameters["@PetName"].Value;

                CloseConnection();
            }
            return petName;
        }

        private SqlParameter CreateParameter(string name, object value, SqlDbType type, int size) {
            return new SqlParameter() {
                ParameterName = name,
                Value = value,
                SqlDbType = type,
                Size = size
            };
        }

        public void ProcessCreditRisk(bool throwEx, int custId) {
            OpenConnection();

            string firstName, lastName;
            string cmd = "Select * From Customers Where CustId = @CustId";
            
            using (SqlCommand command = new SqlCommand(cmd, this.connection)) {
                
                command.Parameters.Add(new SqlParameter("@CustId", custId));

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        reader.Read();
                        firstName = (string)reader["FirstName"];
                        lastName = (string)reader["LastName"];
                    } else {
                        CloseConnection();
                        return;
                    }
                }   
            }

            string cmdRemove = "Delete From Customers Where CustId = @CustId";
            SqlCommand commandRemove = new SqlCommand(cmdRemove, this.connection);
            commandRemove.Parameters.Add(new SqlParameter("@CustId", custId));
            
            string cmdInsert = "Insert Into CreditRisks (FirstName, LastName) Values (@FirstName, @LastName)";
            SqlCommand commandInsert = new SqlCommand(cmdInsert, this.connection);
            commandInsert.Parameters.Add(CreateParameter("@FirstName", firstName, SqlDbType.Char, firstName.Length));
            commandInsert.Parameters.Add(CreateParameter("@LastName", lastName, SqlDbType.Char, lastName.Length));

            SqlTransaction tx = null;

            try {
                // begin a new transaction
                tx = this.connection.BeginTransaction();

                // list commands into transaction
                commandRemove.Transaction = tx;
                commandInsert.Transaction = tx;

                // execute commands
                commandRemove.ExecuteNonQuery();
                commandInsert.ExecuteNonQuery();

                // simulate error
                if (throwEx) {
                    throw new Exception("Database Error: Transaction Failed!");
                }

                // commit if successful
                tx.Commit();

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                if (tx != null) tx.Rollback();
            } finally {
                CloseConnection();
            }
        }
    }
}
