using Data.GenericImplementation.Abstract;

namespace Data.GenericImplementation.Concrete.FieldTypes
{
    class StringField : FieldType<string>
    {
        public override string DatabaseTypeName { get { return "VARCHAR"; } }
    }
}
