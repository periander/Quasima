using System;
using Data.GenericImplementation.Abstract;

namespace Data.GenericImplementation.Concrete.FieldTypes
{
    class GuidField : FieldType<Guid>
    {
        public override string DatabaseTypeName { get { return "UNIQUEIDENTIFIER"; } }
    }
}
