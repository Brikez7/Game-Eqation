using System.Data;
using System.Data.SqlClient;

namespace WPF.RequestDB
{
    internal class TUsers : TPattern
    {
        public TUsers(string name, SqlDataAdapter sqlAdapter, DataTable sqlTable) : base(name, sqlAdapter, sqlTable)
        {
        }
    }
}
