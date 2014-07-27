using System;
using Data.Interface;
using Data.Generic.Abstract;

namespace Data.Generic.Concrete
{
    public class DatabaseFactory<T>
        where T : Database, new()
    {
        public Database GetDatabase() { return new T(); }
    }
}
