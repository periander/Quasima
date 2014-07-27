using Data.Generic.Abstract;

namespace Data.Generic.Concrete.FieldTypes
{
    class StringField : FieldType<string>
    {
        public override string DatabaseTypeName { get { return "VARCHAR"; } }
    }
}
