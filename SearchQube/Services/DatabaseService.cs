using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using SearchQube.Models;

namespace SearchQube.Services
{
    public class DatabaseService
    {
        #region Fields

        private readonly string _connectionString;

        #endregion Fields

        #region Constructors

        public DatabaseService()
        {
            _connectionString = "server=localhost;user=root;database=searchqube;port=3306;password=19720722Db!";
        }

        #endregion Constructors

        #region Methods

        public void AddEquipment(Equipment equipment)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO equipment (TerminalId, Info, Location) VALUES (@TerminalId, @Info, @Location)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TerminalId", equipment.TerminalId);
                    command.Parameters.AddWithValue("@Info", equipment.Info);
                    command.Parameters.AddWithValue("@Location", equipment.Location);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEquipment(string terminalId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM equipment WHERE TerminalId = @TerminalId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TerminalId", terminalId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Equipment> GetAllEquipment()
        {
            var equipmentList = new List<Equipment>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM equipment";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var equipment = new Equipment
                            {
                                TerminalId = reader["TerminalId"].ToString(),
                                Info = reader["Info"].ToString(),
                                Location = reader["Location"].ToString()
                            };
                            equipmentList.Add(equipment);
                        }
                    }
                }
            }

            return equipmentList;
        }

        #endregion Methods
    }
}
