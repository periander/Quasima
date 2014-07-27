using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IDatabase
    {
        bool IsConnected { get; }
        Task<bool> ConnectAsync(string connectionString = "");
    }
}
