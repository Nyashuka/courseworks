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

        private MyDatabaseService()
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

        private void ExecuteQuery(string query)
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        #region Type of room

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

        #endregion

        #region Type of service

        public void CreateTypeOfService(string titleOfService)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO types_of_services (title_of_service_type) ");
            query.Append($"VALUES (\"{titleOfService}\");");

            ExecuteQuery(query.ToString());
        }

        public List<TypeOfService> GetAllTypesOfServices()
        {
            List<TypeOfService> typesOfServices = new List<TypeOfService>();

            string query = "SELECT * FROM types_of_services;";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                typesOfServices.Add(new TypeOfService(rdr.GetInt32(0), rdr.GetString(1)));
            }

            _connection.Close();

            return typesOfServices;
        }

        public void DeleteTypeOfService(int objId)
        {
            string query = $"DELETE FROM types_of_services WHERE Id={objId}";
            ExecuteQuery(query);
        }

        #endregion

        #region Rooms

        public void CreateRoom(int typeOfRoomId, int numberOfRoom)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO rooms (type_of_room_id, number_of_room) ");
            query.Append($"VALUES (\"{typeOfRoomId}\", \"{numberOfRoom}\");");

            ExecuteQuery(query.ToString());
        }

        public List<Room> GetRoomsByDateAndType(DateTime start, DateTime end, TypeOfRoom type)
        {
            List<Room> rooms = new List<Room>();

            StringBuilder query = new StringBuilder();
            query.Append("SELECT * FROM rooms ");
            query.Append($"WHERE type_of_room_id = {type.Id} AND id NOT IN ( ");
            query.Append($"SELECT room_id FROM booking ");
            query.Append($"WHERE ( date_of_end < '{start.ToString("yyyy-MM-dd hh:mm:ss")}' OR ");
            query.Append($"(date_of_start > '{start.ToString("yyyy-MM-dd hh:mm:ss")}' AND ");
            query.Append($"date_of_start > '{end.ToString("yyyy-MM-dd hh:mm:ss")}'))); ");
            
            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query.ToString(), _connection);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                rooms.Add(new Room(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2)));
            }
            _connection.Close();

            return rooms;
        }

        public List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();

            string query = "SELECT * FROM rooms;";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                rooms.Add(new Room(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2)));
            }

            _connection.Close();

            return rooms;
        }

        public void DeleteRoom(int objId)
        {
            string query = $"DELETE FROM rooms WHERE Id={objId}";
            ExecuteQuery(query);
        }

        #endregion


        #region Employee

        public void CreateEmployee(string fullName, string phoneNumber)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO employees (full_name, phone_number) ");
            query.Append($"VALUES (\"{fullName}\", \"{phoneNumber}\");");

            ExecuteQuery(query.ToString());
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            string query = "SELECT * FROM employees;";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                employees.Add(new Employee(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2)));
            }

            _connection.Close();

            return employees;
        }

        public void DeleteEmployee(int objId)
        {
            string query = $"DELETE FROM employees WHERE Id={objId}";
            ExecuteQuery(query);
        }

        #endregion

        #region Services

        public void CreateService(int typeOfServiceId, int selectedEmployeeId, string titleOfService, double pricePerDay)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO services (type_of_service_id, employee_id, title_of_service, price_per_day) ");
            query.Append($"VALUES (\"{typeOfServiceId}\", \"{selectedEmployeeId}\", \"{titleOfService}\", \"{pricePerDay}\");");

            ExecuteQuery(query.ToString());
        }
        
        public List<Service> GetAllServices()
        {
            List<Service> services = new List<Service>();

            string query = "SELECT * FROM services;";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                services.Add(new Service(rdr.GetInt32(0), 
                                         rdr.GetInt32(1), 
                                        (rdr.IsDBNull(2) ? null : rdr.GetInt32(2)), 
                                         rdr.GetString(3), 
                                         rdr.GetDouble(4)));
            }

            _connection.Close();

            return services;
        }
        
        public void UpdateService(int currentServiceId, string titleOfService, double pricePerDay, int type_of_service_id, int selectedEmployeeId)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"UPDATE services set title_of_service=\"{titleOfService}\", price_per_day={pricePerDay}, " +
                         $"employee_id={selectedEmployeeId}, type_of_service_id={type_of_service_id} ");
            query.Append($"WHERE id={currentServiceId}; ");
            
            ExecuteQuery(query.ToString());
        }
        
        public void DeleteService(int objId)
        {
            string query = $"DELETE FROM services WHERE Id={objId}";
            ExecuteQuery(query);
        }

        #endregion

        #region tenant

        public void CreateTenant(string fullName, string phoneNumber)
        {
            string query = $"INSERT INTO tenants (full_name, phon_number) VALUES (\"{fullName}\", \"{phoneNumber}\");";
            
            ExecuteQuery(query);
        }

        #endregion

        #region Booking

        public void CreateBooking(int roomId, string fullName, string phoneNumber, double priceOfBooking, DateTime dateOfStart, DateTime dateOfEnd)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO booking (room_id, tenant_full_name, tenant_phone_number, price_of_booking, date_of_start, date_of_end) ");
            query.Append($"VALUES ({roomId}, \"{fullName}\", \"{phoneNumber}\", {priceOfBooking}, '{dateOfStart.ToString("yyyy-MM-dd hh:mm:ss")}', '{dateOfEnd.ToString("yyyy-MM-dd hh:mm:ss")}');");
            
            ExecuteQuery(query.ToString());
        }
        
        public List<Booking> GetAllBookings()
        {
            List<Booking> bookings = new List<Booking>();

            string query = "SELECT * FROM booking;";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                bookings.Add(new Booking(rdr.GetInt32(0), rdr.GetInt32(1), 
                    rdr.GetString(2), rdr.GetString(3), 
                    rdr.GetDouble(4), DateTime.Parse(rdr.GetString(5)), DateTime.Parse(rdr.GetString(6))));
            }

            _connection.Close();

            return bookings;
        }
        
        public void DeleteBookingById(int id)
        {
            string query = $"DELETE FROM booking WHERE Id={id}";
            ExecuteQuery(query);
        }

        #endregion


        #region Ordered Services

        public List<OrderedService> GetAllOrderedServices()
        {
            List<OrderedService> services = new List<OrderedService>();
            
            string query = "SELECT * FROM ordered_services";
            
            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                services.Add(new OrderedService(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2)));
            }

            _connection.Close();

            return services;
        }

        public void CreateOrderedService(int bookingId, int serviceId)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO ordered_services (booking_id, service_id) ");
            query.Append($"VALUES ({bookingId}, {serviceId});");

            ExecuteQuery(query.ToString());
        }

        #endregion

        #region booking_addition_information

        public void CreateBookingAdditionInformation(int bookingId, string breedOfAnimal, 
                                                     string infoAboutHealth, string infoAboutNeeds)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO booking_addition_information (booking_id, breed_of_animal, info_about_animals_health, info_about_animals_needs) ");
            query.Append($"VALUES ({bookingId}, \"{breedOfAnimal}\", \"{infoAboutHealth}\", \"{infoAboutNeeds}\"); ");
            
            ExecuteQuery(query.ToString());
        }
        
        public void DeleteBookingAdditionInformationById(int id)
        {
            string query = $"DELETE FROM booking_addition_information WHERE Id={id}";
            
            ExecuteQuery(query);
        }

        #endregion


    }
}