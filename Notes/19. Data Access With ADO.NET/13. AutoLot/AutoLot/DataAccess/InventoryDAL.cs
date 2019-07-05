
using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using AutoLot.Models;

namespace AutoLot.AutoLotDAL {
    public class InventoryDAL {

        private readonly string connectionString;
        private SqlConnection connection;

        public InventoryDAL(string connectionString) {
            this.connectionString = connectionString;
            connection = new SqlConnection(connectionString);
        }

        private void OpenConnection() {
            connection.Open();
        }

        private void CloseConnection() {
            if (!(connection.State == ConnectionState.Closed)) {
                connection.Close();
            }
        }


        public List<Car> GetInventory() {
            OpenConnection();
            List<Car> cars = new List<Car>();
            string cmd = "SELECT * FROM INVENTORY";
            using (SqlCommand command = new SqlCommand(cmd, connection)) {
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        cars.Add(new Car() {
                            PetName = (string)reader["PetName"],
                            Make = (string)reader["Make"],
                            CarId = (int)reader["CarId"],
                            Color = (string)reader["Color"]
                        });
                    }
                }
            }
            CloseConnection();
            return cars;
        }

        public Car GetCarById(int id) {
            OpenConnection();
            Car car = null;
            string cmd = "Select * From Inventory  Where CarId = @CarId";
            using (SqlCommand command = new SqlCommand(cmd, connection)) {
                command.Parameters.Add(new SqlParameter() {
                    ParameterName = "@CarId",
                    Value = id,
                    SqlDbType = SqlDbType.Int
                });
                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        car = new Car() {
                            Make = (string)reader["Make"],
                            Color = (string)reader["Color"],
                            CarId = (int)reader["CarId"],
                            PetName = (string)reader["PetName"]
                        };
                    }
                }
            }
            CloseConnection();
            return car;
        }

        public bool AddCar(Car car, out int id) {
            OpenConnection();
            string cmd = "INSERT INTO INVENTORY (PetName, Make, Color) OUTPUT INSERTED.CarId VALUES ( @PetName, @Make, @Color )";
            using (SqlCommand command = new SqlCommand(cmd, connection)) {
                command.Parameters.Add(new SqlParameter() {
                    ParameterName = "@PetName",
                    Value = car.PetName,
                    SqlDbType = SqlDbType.Char,
                    Size = car.PetName.Length
                });

                command.Parameters.Add(new SqlParameter() {
                    ParameterName = "@Make",
                    Value = car.Make,
                    SqlDbType = SqlDbType.Char,
                    Size = car.Make.Length
                });

                command.Parameters.Add(new SqlParameter() {
                    ParameterName = "@Color",
                    Value = car.Color,
                    SqlDbType = SqlDbType.Char,
                    Size = car.Color.Length
                });
                try {
                    id = (int) command.ExecuteScalar();
                } catch(SqlException ex) {
                    id = -1;
                    return false;
                }
            }
            CloseConnection();
            return true;
        }

        public bool AddCar(string petName, string make, string color, out int id) {
            return AddCar(new Car() {
                PetName = petName,
                Make = make,
                Color = color
            }, out id);
        }

        public int DeleteCar(int id) {
            OpenConnection();
            int rowsAffected;
            string cmd = "DELETE FROM INVENTORY WHERE CarId = @carID";
            using(SqlCommand command = new SqlCommand(cmd, connection)) {
                command.Parameters.Add(new SqlParameter() {
                    ParameterName = "@carId",
                    Value = id,
                    SqlDbType = SqlDbType.Int
                });
                try {
                    rowsAffected = command.ExecuteNonQuery();
                } catch (SqlException ex) {
                    return -1;
                }
            }
            CloseConnection();
            return rowsAffected;
        }

        public int UpdatePetName(int carId, string petName) {
            OpenConnection();
            int rowsAffected;
            string cmd = "UPDATE INVENTORY SET PetName = @PetName WHERE CarId = @CarId";
            using (SqlCommand command = new SqlCommand(cmd, connection)) {
                command.Parameters.Add(new SqlParameter() {
                    ParameterName = "@PetName",
                    Value = petName,
                    SqlDbType = SqlDbType.Char,
                    Size = petName.Length
                });

                command.Parameters.Add(new SqlParameter() {
                    ParameterName = "@CarId",
                    Value = carId,
                    SqlDbType = SqlDbType.Int
                });

                try {
                    rowsAffected = command.ExecuteNonQuery();
                } catch(SqlException ex) {
                    return -1;
                }
            }
            CloseConnection();
            return rowsAffected;
        }
    }
}
