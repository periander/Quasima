using System;
using Data.Generic.Abstract;

namespace Data.Generic.Concrete.FieldTypes
{
    public class GuidFieldType : FieldType<Guid>
    {
        public override string DatabaseTypeName { get { return "GUID"; } }
    }
}
