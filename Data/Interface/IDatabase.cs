using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IDatabase
    {
        bool IsConnected { get; }
        Task<bool> Connect(CancellationToken ct, string connectionString = "");
        Task<bool> Disconnect(CancellationToken ct);

        Task<IList<ITableDefinition>> GetTables(CancellationToken ct);
        Task<ITableDefinition> GetTable(CancellationToken ct, string tableName);

        IList<IFieldType> ValidFieldTypes { get; }

    }
}
