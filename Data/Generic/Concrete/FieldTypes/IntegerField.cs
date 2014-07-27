using Data.Generic.Abstract;

namespace Data.Generic.Concrete.FieldTypes
{
    public class IntegerField : FieldType<int>
    {
        public override string DatabaseTypeName { get { return "INT"; } }
    }
}
