using System.Data;
using System.Data.SqlClient;

namespace WPF.RequestDB
{
    internal class TRecordes : TPattern
    {
        public TRecordes(string name, SqlDataAdapter sqlAdapter, DataTable sqlTable) : base(name, sqlAdapter, sqlTable)
        {
        }
        public void addEntry(SqlConnection sqlConnection, string name, string password)
        {
            SqlCommand cmdAdd = new SqlCommand($"INSERT INTO [{_name}] (NameUser, Recordes) VALUES (@NameUser, @Recordes)", sqlConnection);

            cmdAdd.Parameters.AddWithValue("@NameUser", name);
            cmdAdd.Parameters.AddWithValue("@Recordes", password);

            cmdAdd.ExecuteNonQuery();
        }
        public void seachEntriers(SqlConnection sqlConnection, string nameUser)
        {
            SqlCommand cmdSearch = new SqlCommand($"SELECT * FROM [{_name}] WHERE NameUser = @NameUser", sqlConnection);
            cmdSearch.Parameters.AddWithValue("@NameUser", nameUser);

            _sqlTable = new DataTable();
            _sqlAdapter = new SqlDataAdapter(cmdSearch);
        }
        public void sortEntriers(SqlConnection sqlConnection, string sort)
        {
            SqlCommand cmdSort = new SqlCommand($"SELECT * FROM [{_name}] ORDER BY Recordes {sort}", sqlConnection);
            _sqlTable = new DataTable();
            _sqlAdapter = new SqlDataAdapter(cmdSort);
        }
    }
}
