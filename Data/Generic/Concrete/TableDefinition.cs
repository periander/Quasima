
using Data.Interface;
using System.Collections.Generic;

namespace Data.Generic.Concrete
{
    class TableDefinition : ITableDefinition
    {
        public string Name { get; set; }

        private readonly RowDefinition _rowDefinition = new RowDefinition();
        public IRowDefinition RowDefinitions { get { return _rowDefinition; } }
    }
}
