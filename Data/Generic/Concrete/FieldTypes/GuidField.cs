using System;
using Data.Generic.Abstract;

namespace Data.Generic.Concrete.FieldTypes
{
    class GuidField : FieldType<Guid>
    {
        public override string DatabaseTypeName { get { return "UNIQUEIDENTIFIER"; } }
    }
}
