using System.Collections.Generic;

namespace Data.Interface
{
    public interface IRowList : IEnumerable<IRow>
    {
        IList<IRow> Rows { get; }
    }
}
