using System;

namespace Data.Interface
{
    interface IFieldType
    {
        string LogicalTypeName { get; }
        string DatabaseTypeName { get; }
        Type LogicalTypeType { get; }
        bool HasLength { get; }
    }
}
