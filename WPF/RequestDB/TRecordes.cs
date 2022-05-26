using System.Data;
using System.Data.SqlClient;

namespace WPF.RequestDB
{
    internal class TRecordes : TPattern
    {
        public TRecordes(string name, SqlDataAdapter sqlAdapter, DataTable sqlTable) : base(name, sqlAdapter, sqlTable)
        {
        }
    }
}
