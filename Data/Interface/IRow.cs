using System.Collections.Generic;

namespace Data.Interface
{
    public interface IRow : IEnumerable<IField>
    {
        IList<IField> Fields { get; }
        IRowDefinition RowDefinition { get; }
    }
}
