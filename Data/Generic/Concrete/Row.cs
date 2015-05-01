using Data.Interface;
using System;
using System.Collections.Generic;

namespace Data.Generic.Concrete
{
    public class Row : IRow
    {
        private readonly IRowDefinition _rowDefinition;
        private readonly IList<IField> _fields = new List<IField>();

        public Row(IRowDefinition rowDefinition = null) // We make this an optional paramter - but really it's not, this is just so we can throw a relevant argument null exception in case someone uses the default constructor when we don't want them to (they might try and do it via reflection when returned a collection of IRows which are inherently this type - maybe I'm overthinking this...). 
        {
            if (rowDefinition == null)
            {
                throw new ArgumentNullException("rowDefinition", "Row cannot be instantiated without row definition parameter.");
            }
            _rowDefinition = rowDefinition;
            foreach(var fieldDefinition in _rowDefinition.Fields)
            {
                _fields.Add(new Field(fieldDefinition));
            }
        }

        public IList<IField> Fields
        {
            get { return this._fields; }
        }

        protected void SetValues(IList<object> values)
        {
            for(int i = 0, iMax = values.Count; i < iMax; i++)
            {
                foreach(var field in _fields)
                {
                    if(field.FieldDefinition.Position == i)
                    {
                        field.Value = values[i];
                    }
                }
            }
        }


        public IRowDefinition RowDefinition
        {
            get { return _rowDefinition; }
        }

        public IEnumerator<IField> GetEnumerator()
        {
            return Fields.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Fields.GetEnumerator();
        }

        public IField this[string fieldName]
        {
            get
            {
                IField ret = null;
                foreach (var field in _fields)
                {
                    if (field.FieldDefinition.Name == fieldName)
                    {
                        ret = field;
                    }
                }
                return ret;
            }
        }
    }
}
