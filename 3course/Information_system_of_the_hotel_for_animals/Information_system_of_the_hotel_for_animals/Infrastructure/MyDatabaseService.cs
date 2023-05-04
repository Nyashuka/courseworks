using System.Data.SQLite;
using System.IO;

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
                if(_instance == null)
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
    }
}