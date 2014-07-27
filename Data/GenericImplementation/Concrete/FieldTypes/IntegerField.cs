using Data.GenericImplementation.Abstract;

namespace Data.GenericImplementation.Concrete.FieldTypes
{
    class IntegerField : FieldType<int>
    {
        public override string DatabaseTypeName { get { return "INT"; } }
    }
}
