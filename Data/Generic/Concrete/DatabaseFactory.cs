using System;
using Data.Interface;
using Data.Generic.Abstract;

namespace Data.Generic.Concrete
{
    public class DatabaseFactory<T> : IDatabaseFactory
        where T : IDatabase, new()
    {
        public IDatabase GetDatabase() { return new T(); }
    }
}
