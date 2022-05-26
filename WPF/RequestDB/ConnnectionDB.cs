using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace WPF.RequestDB
{
    internal class ConnnectionDB
    {
        private SqlConnection _sqlConnection;
        public ConnnectionDB()
        {
            string beginPathSqlDB = ConfigurationManager.ConnectionStrings["BeginPathConnection"].ConnectionString;
            string endPathSqlDB = ConfigurationManager.ConnectionStrings["EndPathConnection"].ConnectionString;
            string pathDirectory = Directory.GetCurrentDirectory();
            _sqlConnection = new SqlConnection($"{beginPathSqlDB + pathDirectory + endPathSqlDB}");
        }
        private ConnnectionDB _connection
        {
            get
            {
                return _connection;
            }
            set
            {
                if (_connection == null)
                {
                    _connection = new ConnnectionDB();
                }
                else
                {

                }
            }
        }
        public void Connect() 
        {
            _connection = new ConnnectionDB();
        }
        public SqlConnection getSqlConnection() => _sqlConnection;
        public void openConnection() => _sqlConnection.Open();
        public void closeConnection() => _sqlConnection.Close();
    }
}
