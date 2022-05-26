using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WPF.RequestDB
{
    internal class TPattern
    {
        private string _name;
        private SqlDataAdapter _sqlAdapter;
        private DataTable _sqlTable;

        public TPattern(string name, SqlDataAdapter sqlAdapter, DataTable sqlTable)
        {
            _name = name;
            _sqlAdapter = sqlAdapter;
            _sqlTable = sqlTable;
        }

        public string[] GetColums(SqlConnection sqlConnection)
        {
            List<string> colums = new List<string>();

            SqlCommand cmdRead = new SqlCommand($"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @NameTable", sqlConnection);
            cmdRead.Parameters.AddWithValue("@NameTable", _name);

            SqlDataReader sqlDataReader = cmdRead.ExecuteReader();
            while (sqlDataReader.Read())
            {
                colums.Add(item: sqlDataReader.GetValue(3).ToString());
            }
            return colums.ToArray();
        }
        public DataView CompletionTable(SqlConnection sqlConnection) 
        {
            SqlCommand cmdView = new SqlCommand($"SELECT * FROM [{_name}]", sqlConnection);
            _sqlTable = new DataTable();
            _sqlAdapter = new SqlDataAdapter(cmdView);

            _sqlTable = new DataTable();
            _sqlAdapter.Fill(_sqlTable);
            return _sqlTable.DefaultView;
        }
    }
}
