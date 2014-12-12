using System.Collections.Generic;

namespace Data.Interface
{
    interface IRow
    {
        IList<IField> Fields { get; }
        IRowDefinition RowDefinition { get; }
    }
}
