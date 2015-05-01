using System.Collections.Generic;

namespace Data.Interface
{
    using System;

    public interface ITable
    {
        ITableDefinition TableDefinition { get; }
    }
}
