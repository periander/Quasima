using System;
using Data.Generic.Abstract;

namespace Data.Generic.Concrete.FieldTypes
{
    public class GuidField : FieldType<Guid>
    {
        public override string DatabaseTypeName { get { return "GUID"; } }
    }
}
