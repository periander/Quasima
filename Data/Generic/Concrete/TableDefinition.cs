using Data.Interface;

namespace Data.Generic.Concrete
{
    public class TableDefinition : ITableDefinition
    {
        public TableDefinition(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        private readonly RowDefinition _rowDefinition = new RowDefinition();
        public IRowDefinition RowDefinition { get { return _rowDefinition; } }
    }
}
