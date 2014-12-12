using Data.Generic.Abstract;

namespace Data.Generic.Concrete.FieldTypes
{
    public class DoubleFieldType : FieldType<double>
    {
        public override string DatabaseTypeName { get { return "DOUBLE"; } }
    }
}
