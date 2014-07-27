using System;
using Data.Interface;

namespace Data.GenericImplementation.Concrete
{
    public class DatabaseFactory<T> : IDatabaseFactory 
        where T : Abstract.Database, new()
    {
        public T GetDatabase() {  return new T(); }
        IDatabase IDatabaseFactory.GetDatabase() { return new T(); }
    }
}
