using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;
using Information_system.Models;

namespace Information_system.Infrastructure
{
    public class MyDatabaseService
    {
        private const string DatabasePath = "database/database.db";
        private const string ConnectionString = "Data Source=" + DatabasePath;

        private SQLiteConnection _connection;

        private static MyDatabaseService _instance;

        public static MyDatabaseService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MyDatabaseService();

                return _instance;
            }
        }

        public MyDatabaseService()
        {
            bool dataBaseExist = File.Exists(DatabasePath);

            if (!dataBaseExist)
            {
                SQLiteConnection.CreateFile(DatabasePath);
            }

            _connection = new SQLiteConnection(ConnectionString);

            if (!dataBaseExist)
            {
                _connection.Open();
                DatabaseInitializer databaseInitializer = new DatabaseInitializer(_connection);
                databaseInitializer.Initialize();
                _connection.Close();
            }
        }

        public void ExecuteQuery(string query)
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void CreateTypeOfRoom(string title, string area, string pricePerDay)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO types_of_room (type_title, room_area, price_per_day) ");
            query.Append($"VALUES (\"{title}\",\"{area}\",\"{pricePerDay}\");");

            ExecuteQuery(query.ToString());
        }

        public List<TypeOfRoom> GetAllTypesOfRooms()
        {
            List<TypeOfRoom> typeOfRooms = new List<TypeOfRoom>();

            string query = "SELECT * FROM types_of_room;";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                typeOfRooms.Add(new TypeOfRoom(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3)));
            }
            _connection.Close();   
            
            return typeOfRooms;
        }

        public void DeleteTypeOfRoom(int objId)
        {
            string query = $"DELETE FROM types_of_room WHERE Id={objId}";
            ExecuteQuery(query);
        }
    }
}