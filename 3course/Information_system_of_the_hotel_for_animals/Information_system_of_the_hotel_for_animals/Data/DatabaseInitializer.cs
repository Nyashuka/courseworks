using System.Data.SQLite;
using System.IO;
using System.Text;

namespace Information_system_of_the_hotel_for_animals.Data
{
    public class DatabaseInitializer
    {
        private const string DatabaseSqlPath = "database/creating_database_sql.sql";
        private readonly SQLiteConnection _connection;
        
        public DatabaseInitializer(SQLiteConnection connection)
        {
            _connection = connection;
        }

        public void Initialize()
        {
            SQLiteCommand command = new SQLiteCommand(ReadDatabaseSql(), _connection);
            command.ExecuteNonQuery();
        }

        private string ReadDatabaseSql()
        {
            return File.ReadAllText(DatabaseSqlPath);
        }  
    }
}
