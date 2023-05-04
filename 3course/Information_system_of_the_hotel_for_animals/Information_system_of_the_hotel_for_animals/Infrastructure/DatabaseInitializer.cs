using System.Data.SQLite;
using System.IO;

namespace Information_system.Infrastructure
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
