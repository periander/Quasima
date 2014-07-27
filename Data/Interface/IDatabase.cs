using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IDatabase
    {
        bool IsConnected { get; }
        Task<bool> Connect(string connectionString = "");
        Task<bool> Disconnect();
        
        Task<IList<ITableDefinition>> GetTables();

        IList<IFieldType> ValidFieldTypes { get; } 
    }
}
