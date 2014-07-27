using System;
using System.Data;
using System.Data.SqlClient;
using Data.Interface;
using System.Threading.Tasks;

namespace Data.SqlServer2012
{
    public class Database : GenericImplementation.Abstract.Database
    {

        SqlConnection _connection;

        public override bool IsConnected
        {
            get { return _connection != null && _connection.State == ConnectionState.Open; }
        }

        public override async Task<bool> ConnectAsync(string connectionString = "")
        {
            if(_connection == null || !IsConnected)
            {
                _connection = string.IsNullOrEmpty(connectionString) ? new SqlConnection() : new SqlConnection(connectionString);
                await _connection.OpenAsync();
            }
            return IsConnected;
        }



    }
}
