using System;
using Data.Interface;

namespace Data.Generic.Abstract
{
    public abstract class FieldType<T> : IFieldType
    {
        public string LogicalTypeName { get { return LogicalTypeType.ToString(); } }
        public abstract string DatabaseTypeName { get; }
        public Type LogicalTypeType { get { return typeof(T); } }
        public bool HasLength { get { return LogicalTypeType == typeof(string); } }
        
    }
}
