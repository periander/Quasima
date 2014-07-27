using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Data.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.SqlServer2012
{
    public class Database : IDatabase
    {

        private SqlConnection _connection;

        public bool IsConnected
        {
            get { return _connection != null && _connection.State == ConnectionState.Open; }
        }

        public async Task<bool> Connect(string connectionString = "")
        {
            if(_connection == null || !IsConnected)
            {
                _connection = string.IsNullOrEmpty(connectionString) ? new SqlConnection() : new SqlConnection(connectionString);
                await _connection.OpenAsync();
            }
            return IsConnected;
        }


#pragma warning disable 1998
        public async Task<bool> Disconnect()
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
        public async Task<IList<ITableDefinition>> GetTables()
#pragma warning restore 1998
        {
            if (!_tables.Any())
            {
                var tables = _connection.GetSchema("Tables");
                foreach(DataRow tableSchemaRow in tables.Rows)
                {
                    var tableName = tableSchemaRow[2].ToString();
                    var restrictions = new string[] { "", "", tableName, ""};
                    var tableSchema = _connection.GetSchema("Tables", restrictions);
                }
            }

            return _tables;
        }
    }
}
