using System;
using Data.Interface;

namespace Data.GenericImplementation.Concrete
{
    public class DatabaseFactory<T> : IDatabaseFactory
        where T : IDatabase, new()
    {
        public IDatabase GetDatabase() { return new T(); }
    }
}
