using System;
using System.Collections.Generic;

namespace Data.Generic.Concrete
{
    using Data.Interface;

    public class RowList : IRowList
    {
        private readonly IList<IRow> _rows = new List<IRow>();

        public IList<IRow> Rows
        {
           get { return _rows; }
        }

        IEnumerator<IRow> IEnumerable<IRow>.GetEnumerator()
        {
            return Rows.GetEnumerator();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Rows.GetEnumerator();
        }
}
}
