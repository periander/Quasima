using Data.Interface;
using System.Threading.Tasks;

namespace Data.GenericImplementation.Abstract
{
    public abstract class Database : IDatabase
    {
        public abstract bool IsConnected { get; }
        
        /// <summary>
        /// Implementers must override this function.
        /// Unfortunately cannot make it abstract (async modifier).
        /// </summary>
        public virtual async Task<bool> ConnectAsync(string connectionString = "")
        {
            await Task.Yield();
            return false;
        }


    }
}
