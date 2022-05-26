using System.Data;
using System.Data.SqlClient;

namespace WPF.RequestDB
{
    internal class TUsers : TPattern
    {
        public TUsers(string name, SqlDataAdapter sqlAdapter, DataTable sqlTable) : base(name, sqlAdapter, sqlTable)
        {
        }
        public void addEntry(SqlConnection sqlConnection, string name, string password)
        {
            SqlCommand cmdAdd = new SqlCommand($"INSERT INTO [{_name}] (NameUser, Password) VALUES (@NameUser, @Password)", sqlConnection);

            cmdAdd.Parameters.AddWithValue("@NameUser", name);
            cmdAdd.Parameters.AddWithValue("@Password", password);

            cmdAdd.ExecuteNonQuery();
        }
        public bool seachAccaunt(SqlConnection sqlConnection, string name, string password) 
        {
            SqlCommand cmdSearch = new SqlCommand($"SELECT * FROM [{_name}] WHERE NameUser = @NameUser AND Password = @Password", sqlConnection);

            cmdSearch.Parameters.AddWithValue("@NameUser", name);
            cmdSearch.Parameters.AddWithValue("@Password", password);

            SqlDataReader sqlDataReader = cmdSearch.ExecuteReader();
            return sqlDataReader.HasRows;
        }
    }
}
