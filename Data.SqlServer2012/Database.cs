using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Data.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.SqlServer2012
{
    public class Database : Generic.Abstract.Database
    {

        private SqlConnection _connection;

        public override bool IsConnected
        {
            get { return _connection != null && _connection.State == ConnectionState.Open; }
        }

        public override async Task<bool> Connect(string connectionString = "")
        {
            if(_connection == null || !IsConnected)
            {
                _connection = string.IsNullOrEmpty(connectionString) ? new SqlConnection() : new SqlConnection(connectionString);
                await _connection.OpenAsync();
            }
            return IsConnected;
        }


#pragma warning disable 1998
        public override async Task<bool> Disconnect()
#pragma warning restore 1998
        {
            if(_connection != null && IsConnected)
            {
                _connection.Close();
            }
            return !IsConnected;
        }

        private readonly IList<ITableDefinition> _tables = new List<ITableDefinition>();

#pragma warning disable 1998
        public override async Task<IList<ITableDefinition>> GetTables()
#pragma warning restore 1998
        {
            if (!_tables.Any())
            {
                var tables = _connection.GetSchema("Tables");
                foreach(var tableSchemaRow in tables.Rows)
                {
                    int i = 0;
                }
            }

            return _tables;
        }
    }
}
