using System.Data.SQLite;
using System.IO;

namespace Information_system_of_the_hotel_for_animals.Data
{
    public class DatabaseService
    {
        private const string DatabasePath = "database/database.db";
        private const string ConnectionString = "Data Source=" + DatabasePath;

        private readonly SQLiteConnection _connection;

        public DatabaseService()
        {
            bool dataBaseExist = File.Exists(DatabasePath);

            if (!dataBaseExist)
            {
                SQLiteConnection.CreateFile(DatabasePath);
            }

            _connection = new SQLiteConnection(ConnectionString);

            if(!dataBaseExist)
            {
                _connection.Open();
                DatabaseInitializer databaseInitializer = new DatabaseInitializer(_connection);
                databaseInitializer.Initialize();
                _connection.Close();
            }
        }
      
    }
}
