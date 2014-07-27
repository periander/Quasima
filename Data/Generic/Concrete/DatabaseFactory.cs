using Data.Interface;

namespace Data.Generic.Concrete
{
    public class DatabaseFactory<T> : IDatabaseFactory
        where T : IDatabase, new()
    {
        public IDatabase CreateDatabase() { return new T(); }

    }
}
