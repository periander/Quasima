using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Interface;

namespace Data.Generic.Abstract
{
    public abstract class Database : IDatabase
    {
        public abstract bool IsConnected { get; }

        public virtual async Task<bool> Connect(string connectionString = "")
        {
            await Task.Yield();
            return false;
        }

        public virtual async Task<bool> Disconnect()
        {
            await Task.Yield();
            return false;
        }

        public virtual async Task<IList<ITableDefinition>> GetTables()
        {
            await Task.Yield();
            return null;
        }
    }
}
