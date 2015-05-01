using Data.Interface;
using System;

namespace Data.Generic.Concrete
{
    public class Table : ITable
    {
        private readonly ITableDefinition _tableDefinition;

        public Table(ITableDefinition tableDefinition = null) // We make this an optional paramter - but really it's not, this is just so we can throw a relevant argument null exception in case someone uses the default constructor when we don't want them to (they might try and do it via reflection when returned a collection of ITables which are inherently this type - maybe I'm overthinking this...). 
        {
            if (tableDefinition == null)
            {
                throw new ArgumentNullException("tableDefinition", "Table cannot be instantiated without table definition parameter.");
            }
            _tableDefinition = tableDefinition;
        }

        public ITableDefinition TableDefinition
        {
            get { return _tableDefinition; }
        }
    }
}
