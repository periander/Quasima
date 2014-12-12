using Data.Generic.Abstract;

namespace Data.Generic.Concrete.FieldTypes
{
    public class BooleanFieldType : FieldType<bool>
    {
        public override string DatabaseTypeName { get { return "BOOL"; } }
    }
}
