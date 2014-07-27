using Data.Generic.Abstract;

namespace Data.Generic.Concrete.FieldTypes
{
    class DoubleField : FieldType<double>
    {
        public override string DatabaseTypeName { get { return "FLOAT"; } }
    }
}
