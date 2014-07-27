using Data.GenericImplementation.Abstract;

namespace Data.GenericImplementation.Concrete.FieldTypes
{
    class DoubleField : FieldType<double>
    {
        public override string DatabaseTypeName { get { return "FLOAT"; } }
    }
}
