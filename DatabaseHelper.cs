using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace CityDirectory
{
    public static class DatabaseHelper
    {
        private const string ConnectionString = "Data Source=CityDirectory.db;Version=3;";

        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string createTableQuery = @"CREATE TABLE IF NOT EXISTS Enterprises (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Name TEXT NOT NULL,
                                            Address TEXT NOT NULL,
                                            Phone TEXT NOT NULL)";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void AddEnterprise(Enterprise enterprise)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Enterprises (Name, Address, Phone) VALUES (@Name, @Address, @Phone)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", enterprise.Name);
                    command.Parameters.AddWithValue("@Address", enterprise.Address);
                    command.Parameters.AddWithValue("@Phone", enterprise.Phone);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<Enterprise> GetAllEnterprises()
        {
            var enterprises = new List<Enterprise>();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Enterprises";
                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        enterprises.Add(new Enterprise
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            Phone = reader["Phone"].ToString()
                        });
                    }
                }
            }

            return enterprises;
        }
    }
}
